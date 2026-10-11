# Plano de Reinstalação do Ambiente - DialcronSB

Requisito: formatação do PC. Este documento cobre desde o setup zero
até o app rodando em emulador Android + Windows, tudo via linha de comando.

## 0. Antes de formatar

- Commit + push: `git add -A && git commit -m "..." && git push`
  (confirmar que `git status` retorna "up to date")
- Backup dos secrets Android (necessários p/ APK Release assinado):
  `ANDROID_KEYSTORE_BASE64`, `ANDROID_KEYSTORE_PASSWORD`, `ANDROID_KEY_ALIAS`, `ANDROID_KEY_PASSWORD`
- Backup de credenciais/senhas (GitHub PAT, e-mail)
- Anotar a lista de software instalado (ver seção 1) para reinstalar

## 1. Pós-Formatação - Instalação das Ferramentas

| Software | Versão | Motivo |
|---|---|---|
| Git for Windows | última | trabalhar com o repo |
| .NET SDK | 10.x (ex.: 10.0.302) | compilar MAUI/.NET 10 |
| Visual Studio 18 Community | última | IDE + tooling Android/emulador |
| JDK (Adoptium) | 21 LTS | requisito do target Android .NET 10 (API 36) |
| Workload MAUI | via `dotnet workload install maui` | framework do projeto |

Comandos:
```bash
winget install Git.Git
winget install Microsoft.DotNet.SDK.10
# JDK: baixar Adoptium 21 (ex.: https://adoptium.net) e instalar
# VS: baixar visualstudio.com + VS Installer
dotnet workload install maui --ignore-failed-sources
```

Demais dependências (restauradas via NuGet, sem instalação manual):
- sqlite-net-pcl, Plugin.Maui.Calendar, Microsoft.Maui.Controls

## 2. Clonar o Repositório

```bash
git clone https://github.com/arthurmdiniz/DialcronSB.git
cd DialcronSB
```

## 3. Instalar Android SDK (base) - via MSBuild do próprio MAUI

Parte do .NET Android já traz o installer. Executar de `C:\Git\DialcronSB`:

```powershell
dotnet build DialcronSB\DialcronSB.csproj -f net10.0-android -t:InstallAndroidDependencies `
  -p:AndroidSdkDirectory="$env:LOCALAPPDATA\Android\Sdk" `
  -p:JavaSdkDirectory="C:\Program Files\Microsoft\jdk-21.0.9.10-hotspot" `
  -p:AcceptAndroidSDKLicenses=true
# (ajustar o caminho do JDK conforme a instalação)
```

Instala: platform-tools, platforms;android-36, build-tools e cmdline-tools (sdkmanager/avdmanager).

## 4. Instalar Emulador + System Image

```powershell
$sdk = "$env:LOCALAPPDATA\Android\Sdk"
$sdkman = Get-ChildItem "$sdk\cmdline-tools\*\bin\sdkmanager.bat" | Select-Object -First 1
& $sdkman.FullName "emulator"
& $sdkman.FullName "system-images;android-36;google_apis;x86_64"
```

(~1,5-2 GB de download)

## 5. Criar o AVD

```powershell
$avdman = Join-Path (Split-Path $sdkman.FullName) "avdmanager.bat"
"no" | & $avdman create avd -n DialcronAVD -k "system-images;android-36;google_apis;x86_64" -d pixel_7
```

## 6. Aceleração do Emulador (Hypervisor Platform) - Admin

```powershell
# PowerShell como Administrador
Enable-WindowsOptionalFeature -Online -FeatureName HypervisorPlatform -NoRestart
# reiniciar o PC
# validar:
& "$sdk\emulator\emulator-check.exe" accel
```

## 7. Variáveis de Ambiente (usuário)

```powershell
[Environment]::SetEnvironmentVariable('ANDROID_HOME', "$env:LOCALAPPDATA\Android\Sdk", 'User')
[Environment]::SetEnvironmentVariable('JAVA_HOME',  'C:\Program Files\Microsoft\jdk-21.0.9.10-hotspot', 'User')
```

E apontar o VS para o SDK adicionando no `DialcronSB\DialcronSB.csproj.user`
(arquivo local, não vai pro git):

```xml
<Project>
  <PropertyGroup>
    <ActiveDebugFramework>net10.0-android</ActiveDebugFramework>
    <AndroidSdkDirectory>C:\Users\<seu>\AppData\Local\Android\Sdk</AndroidSdkDirectory>
    <JavaSdkDirectory>C:\Program Files\Microsoft\jdk-21.0.9.10-hotspot</JavaSdkDirectory>
  </PropertyGroup>
</Project>
```

## 8. Restore + Compilação (Windows + Android)

```powershell
cd C:\Git\DialcronSB\DialcronSB
dotnet restore
dotnet build -f net10.0-windows10.0.19041.0
dotnet build -f net10.0-android
```

## 9. Rodar no Emulador

```powershell
# iniciar o emulador (pode ficar aberto)
& "$env:LOCALAPPDATA\Android\Sdk\emulator\emulator.exe" -avd DialcronAVD

# em outro terminal, deploy + run
cd C:\Git\DialcronSB\DialcronSB
dotnet run -f net10.0-android
# ou no VS: selecionar o dispositivo "DialcronAVD" no dropdown e F5
```

## 10. Publicação Standalone (Windows) - opcional

```powershell
cd C:\Git\DialcronSB\DialcronSB
.\publish.ps1   # ou: dotnet publish -f net10.0-windows10.0.19041.0 -c Release -o publish
```

> Nota: o `publish/DialcronSBDB.db` é versionado no git e funciona como
> "banco fonte" — ele vem no clone já atualizado.

## Checklist final

- [ ] Git + repo clonado e `git status` limpo
- [ ] .NET SDK 10 + workload maui instalados
- [ ] JDK 21 instalado
- [ ] Android SDK base instalado (`InstallAndroidDependencies`)
- [ ] Emulador + system image instalados
- [ ] AVD `DialcronAVD` criado
- [ ] HypervisorPlatform ativo (após reboot)
- [ ] `ANDROID_HOME` / `JAVA_HOME` configurados
- [ ] `csproj.user` com `AndroidSdkDirectory`
- [ ] Build Windows e Android OK
- [ ] App rodou no emulador
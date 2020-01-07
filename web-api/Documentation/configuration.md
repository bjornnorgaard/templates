# Configuration and Envionment Setup

Everything secret should be configured in the hosting environment. The local `appsettings.json` files should **ONLY** be used for common configuration and **NOT** secrets.

Should secrets be needed during development, these should be put into the `UserSecrets` file, managed by Visual Studio. This file is accessed by right-clicking the `Api.Web` project and selecting `Manage User Secrets`.

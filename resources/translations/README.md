# Translation Files

Place all translation JSON files in this directory. Files should be named according to their language code (e.g. `en-US.json`, `ar-SA.json`).

Each file should contain key-value pairs:
```json
{
    "key": "translated_text",
    "welcome": "Welcome to our server!"
}
```

## 10. ملفات التكوين المتبقية

### `configs/README.md`
```markdown
# Configuration Files

This directory contains all configuration files for DZCP and its plugins.

## Core Files:
- `main-config.yml`: Main framework configuration
- `permissions.json`: Permission system configuration

## Plugin Files:
Plugins should store their configurations in separate files named `pluginname_config.yml`
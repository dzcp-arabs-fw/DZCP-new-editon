#!/bin/bash

# إعداد مسارات أساسية
echo "Setting up directories..."
mkdir -p DZCP/Plugins
mkdir -p DZCP/Configs
mkdir -p DZCP/Logs
mkdir -p DZCP/Dependencies
mkdir -p DZCP/Patches

# إنشاء ملف التهيئة الافتراضي إذا لم يكن موجودًا
CONFIG_FILE="DZCP/Configs/dzcp_config.cfg"
if [ ! -f "$CONFIG_FILE" ]; then
    echo "Creating default configuration file..."
    cat <<EOL > "$CONFIG_FILE"
# Default DZCP Configuration
enable_patches=true
auto_update=false
debug_mode=false
EOL
fi

# تحميل مكتبة Harmony إذا لم تكن موجودة
HARMONY_URL="https://example.com/0Harmony.dll"
HARMONY_PATH="DZCP/Dependencies/0Harmony.dll"
if [ ! -f "$HARMONY_PATH" ]; then
    echo "Downloading Harmony library..."
    curl -L -o "$HARMONY_PATH" "$HARMONY_URL"
fi

echo "Setup completed successfully!"
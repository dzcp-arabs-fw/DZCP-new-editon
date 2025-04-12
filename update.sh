#!/bin/bash

# رابط التحديثات
UPDATE_URL="https://example.com/updates/latest.zip"
UPDATE_DIR="DZCP/Updates"
INSTALL_DIR="DZCP"

# إنشاء مسار التحديثات إذا لم يكن موجودًا
echo "Preparing for updates..."
mkdir -p "$UPDATE_DIR"

# تنزيل التحديثات
echo "Downloading latest updates..."
curl -L -o "$UPDATE_DIR/latest.zip" "$UPDATE_URL"

# استخراج التحديثات
echo "Extracting updates..."
unzip -o "$UPDATE_DIR/latest.zip" -d "$INSTALL_DIR"

# تنظيف ملفات التحديثات المؤقتة
echo "Cleaning up..."
rm -rf "$UPDATE_DIR"

echo "Update applied successfully!"
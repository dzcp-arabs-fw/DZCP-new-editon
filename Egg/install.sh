#!/bin/bash
apt update
apt install -y unzip curl php php-mysql
curl -L https://dzcp.de/download/DZCP-latest.zip -o dzcp.zip
unzip dzcp.zip -d /home/container
rm dzcp.zip

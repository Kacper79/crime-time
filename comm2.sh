#! /bin/bash
expect -c"
spawn git push origin master
expect \"Username\"
send $1
send \"\r\"
expect \"Password\"
send $2
send \"\r\"
interact
set timeout 30"


#! /usr/bin/expect
spawn git push origin master
expect "Username for https://github.com:" 
send "KotMruczyslaw\r"

FROM glassfish:latest

MAINTAINER Ewen Auffret "auffret.ewen@gmail.com"

COPY fileQueue.war /
COPY WebDictionary.war /
COPY start.sh /
COPY password.file /
COPY passwordChange.file /

EXPOSE 22
EXPOSE 8080

ENTRYPOINT ["/start.sh"]
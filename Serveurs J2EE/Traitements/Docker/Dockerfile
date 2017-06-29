FROM glassfish:latest

MAINTAINER Ewen Auffret "auffret.ewen@gmail.com"

COPY wordTraitement.jar /
COPY mysql-connector-java-5.1.6.jar / 
COPY start.sh /
COPY password.file /
COPY passwordChange.file /

ENTRYPOINT ["/start.sh"]
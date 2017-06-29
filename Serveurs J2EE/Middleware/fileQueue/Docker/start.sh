#!/bin/sh

# .war deploy
/usr/local/glassfish4/bin/asadmin start-domain
/usr/local/glassfish4/bin/asadmin -u admin deploy /fileQueue.war

# queue setup
asadmin --host localhost --user admin --passwordfile=/passwordChange.file change-admin-password
bin/asadmin --user admin --host localhost --port 4848 --passwordfile=/password.file enable-secure-admin
asadmin --user admin --passwordfile=/password.file create-jms-resource --restype javax.jms.Queue --property Name=physParsingQueue jms/fileParsingQueue

# restart server
/usr/local/glassfish4/bin/asadmin stop-domain
/usr/local/glassfish4/bin/asadmin start-domain --verbose
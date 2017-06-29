#!/bin/sh

# .war deploy
/usr/local/glassfish4/bin/asadmin start-domain
/usr/local/glassfish4/bin/asadmin -u admin deploy /wordTraitement.jar

# copy the mysql driver
cp /mysql-connector-java-5.1.6.jar $JAVA_HOME/jre/lib/ext/

# queue setup
asadmin --host localhost --user admin --passwordfile=/passwordChange.file change-admin-password
bin/asadmin --user admin --host localhost --port 4848 --passwordfile=/password.file enable-secure-admin

# restart server
/usr/local/glassfish4/bin/asadmin stop-domain
/usr/local/glassfish4/bin/asadmin start-domain --verbose
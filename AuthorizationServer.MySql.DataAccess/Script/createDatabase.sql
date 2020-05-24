CREATE database dbauthenticator;
CREATE USER 'oauth'@'localhost' IDENTIFIED BY 'oauth';
GRANT ALL PRIVILEGES ON dbauthenticator.* TO 'oauth'@'localhost';

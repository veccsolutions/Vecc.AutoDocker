# Description
This solution watches an exposed docker http socket for events and executes a razor template.

* Console application
    * Listens for docker events
    * Executes a razor template https://www.frakkingsweet.com/razor-template-rendering/
    * Writes the results to specified file when the content changes
    * Executes the specified command when the rendered template content changes
    * Uses Serilog for logging
* Contains a .NET Core client library for the Docker socket.
    * Implements the primary GET api's
        * Containers
        * Images
        * Nodes
        * Services
        * Swarm
        * System
        * Real-time event monitoring
        * Tasks
* Dockerfile for building the container

# Requirements
Your docker socket is exposed, and hopefully secured

* https://www.frakkingsweet.com/remote-docker-instance/
* https://www.frakkingsweet.com/securing-the-remote-docker-instance/
* If your socket is secured, you will need to combine your public/private certificate into a pfx file
    * Save with password: `openssl pkcs12 -inkey ~/.docker/key.pem -in ~/.docker/cert.key -export -out ~/.docker/cert.pfx`
    * Save without a password: `openssl pkcs12 -inkey ~/.docker/key.pem -in ~/.docker/cert.key -export -out ~/.docker/cert.pfx -nodes`

# Documentation
Configure your security and host settings in the `/src/Vecc.AutoDocker/appsettings.json` file.

# Related blog posts
* https://www.frakkingsweet.com/razor-template-rendering/
* https://www.frakkingsweet.com/remote-docker-instance/
* https://www.frakkingsweet.com/securing-the-remote-docker-instance/
* https://www.frakkingsweet.com/create-your-own-docker-registry/
* https://www.frakkingsweet.com/docker-swarm-on-debian-and-hyper-v/
* https://www.frakkingsweet.com/add-usersecrets-to-net-core-console-application/

# TODO
* Run as a docker container, windows service or console application
* Examples
    * [HAProxy](https://www.haproxy.org)
    * [NGINX](https://nginx.org/)
    * Any others?
* Documentation

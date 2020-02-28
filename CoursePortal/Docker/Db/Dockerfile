FROM microsoft/mssql-server-linux:latest

RUN apt-get install -y locales \
    && echo "en_US.UTF-8 UTF-8" > /etc/locale.gen \
    && locale-gen
EXPOSE 1433
ENV PATH="/opt/mssql-tools/bin:${PATH}"
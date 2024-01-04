FROM debian:10.7

RUN apt-get update && \
    apt-get install --yes --no-install-recommends autoconf libtool automake make git

RUN GIT_SSL_NO_VERIFY=1 git clone https://github.com/curl/curl --depth 1
RUN cd curl && ./buildconf && ./configure && make -j$(nproc) install && \
    echo /usr/local/lib >> /etc/ld.so.conf.d/local.conf && ldconfig
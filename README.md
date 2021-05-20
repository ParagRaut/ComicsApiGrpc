# ComicsApi gRPC

[![.NET Core](https://github.com/ParagRaut/ComicsApiGrpc/actions/workflows/main.yml/badge.svg)](https://github.com/ParagRaut/ComicsApiGrpc/actions/workflows/main.yml)

ComicsApi example in gRPC which returns comic strip image urls

This is a service which can be consumed by any grpc testing clients e.g. [bloomrpc](https://appimage.github.io/BloomRPC/)

Input can be one of the following
- dilbert
- garfield
- xkcd
- calvinAndHobbs
- no/any random input returns random comic url

Check it live here: [ComicsApi-gRPC](https://random-comics-api-grpc.herokuapp.com/)

### Build instructions

After cloning the repo

```zsh
cd src
dotnet run
```

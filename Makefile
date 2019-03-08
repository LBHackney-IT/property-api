.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose run property-api dotnet build

.PHONY: serve
serve:
	docker-compose up property-api

.PHONY: shell
shell:
	docker-compose run property-api bash

.PHONY: test
test:
	docker-compose build property-api-test && docker-compose up property-api-test

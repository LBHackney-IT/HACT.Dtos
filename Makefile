.PHONY: build
build:
	dotnet build HACT.Dtos

.PHONY: test
test:
	dotnet test

.PHONY: lint
lint:
	-dotnet tool install dotnet-format --tool-path ./local-tools/dotnet-format/
	./local-tools/dotnet-format/dotnet-format

.PHONY: run
run:
	dotnet run --project HousingRepairsOnlineApi
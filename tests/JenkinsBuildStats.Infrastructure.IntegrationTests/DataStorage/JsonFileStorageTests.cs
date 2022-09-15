using JenkinsBuildStats.Infrastructure.DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenkinsBuildStats.Infrastructure.IntegrationTests.DataStorage
{
    public class JsonFileStorageTests
    {
        private const string _storageDirectoryPath = @"\";
        private readonly JsonFileStorage _storage = new JsonFileStorage(new StorageDirectory(_storageDirectoryPath));

        [Fact]
        public async Task SaveAsync_MoqDataType_FileCreatedWithProperContent()
        {
            var data = new TestDataType
            {
                Name = "Some test name"
            };

            const string fileName = "TestDataTypeSaveAsync";
            await _storage.SaveAsync(fileName, data, new CancellationToken());

            var filePath = Path.Combine(_storageDirectoryPath, $"{fileName}.json");

            File.Exists(filePath).Should().BeTrue();
            File.ReadAllText(filePath).Should().Be(@"{""Name"":""Some test name""}");
        }

        [Fact]
        public async Task GetAsync_MoqDataType_FileContentProperlyDeserialized()
        {
            const string fileName = "TestDataTypeGetAsync";
            var filePath = Path.Combine(_storageDirectoryPath, $"{fileName}.json");

            File.WriteAllText(filePath, @"{""Name"":""Another test name""}");
            var actual = await _storage.GetAsync<TestDataType>(fileName, new CancellationToken());

            actual.Should().NotBeNull();
            actual.Name.Should().Be("Another test name");
        }

        [Fact]
        public async Task GetAsync_NoFile_NullReturned()
        {
            const string fileName = "TestDataTypeGetAsyncThatDoesNotExists";
            var filePath = Path.Combine(_storageDirectoryPath, $"{fileName}.json");

            var actual = await _storage.GetAsync<TestDataType>(fileName, new CancellationToken());

            File.Exists(filePath).Should().BeFalse();
            actual.Should().BeNull();
        }
    }
}

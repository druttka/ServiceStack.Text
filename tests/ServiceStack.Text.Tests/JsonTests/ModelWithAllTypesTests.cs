using System;
using System.Collections.Generic;
using NUnit.Framework;
using ServiceStack.Text.Tests.DynamicModels;

namespace ServiceStack.Text.Tests.JsonTests
{
	[TestFixture]
	public class ModelWithAllTypesTests
	{
		[Test]
		public void Can_Serialize()
		{
			var model = ModelWithAllTypes.Create(1);
			var s = JsonSerializer.SerializeToString(model);

			Console.WriteLine(s);
		}

		[Test]
		public void Can_Serialize_list()
		{
			var model = new List<ModelWithAllTypes>
           	{
				ModelWithAllTypes.Create(1),
				ModelWithAllTypes.Create(2)
           	};
			var s = JsonSerializer.SerializeToString(model);

			Console.WriteLine(s);
		}

		[Test]
		public void Can_Serialize_map()
		{
			var model = new Dictionary<string, ModelWithAllTypes>
           	{
				{"A", ModelWithAllTypes.Create(1)},
				{"B", ModelWithAllTypes.Create(2)},
           	};
			var s = JsonSerializer.SerializeToString(model);

			Console.WriteLine(s);
		}

        [Test]
        public void Can_Deserialize()
        {
            var json = "{\"CharValue\":\"c\"}";
            var model = JsonSerializer.DeserializeFromString<ModelWithAllTypes>(json);

            Assert.AreEqual('c', model.CharValue);
        }

        [Test]
        public void Can_Deerialize_list()
        {
            var json = "[{\"CharValue\":\"c\"},{\"CharValue\":\"d\"}]";
            var model = JsonSerializer.DeserializeFromString<List<ModelWithAllTypes>>(json);

            Assert.AreEqual(2, model.Count);
            Assert.AreEqual('c', model[0].CharValue);
            Assert.AreEqual('d', model[1].CharValue);
        }

        [Test]
        public void Can_Deserialize_map()
        {
            var json = "{\"C\":{\"CharValue\":\"c\"},\"D\":{\"CharValue\":\"d\"}}";
            var model = JsonSerializer.DeserializeFromString<Dictionary<string, ModelWithAllTypes>>(json);

            Assert.AreEqual(2, model.Keys.Count);
            Assert.AreEqual('c', ((ModelWithAllTypes)model["C"]).CharValue);
            Assert.AreEqual('d', ((ModelWithAllTypes)model["D"]).CharValue);
        }

	}
}
using Week3B_Emmer.Models;

namespace Week3B_Emmer_UnitTests.BucketTests.Values
{
    internal class BucketValueTests
    {
        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(-100)]
        [Test]
        public void Bucket_NegativeCapacity_CapacitySetToDefault(int capacity)
        {
            //Arrange and Act
            Bucket bucket = new Bucket(capacity);

            //Assert
            Assert.AreEqual(bucket.Capacity, Bucket.DEFAULT_CAPACITY);
        }

        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(-100)]
        [Test]
        public void Bucket_NegativeContent_ContentRemainsZero(int content)
        {
            //Arrange
            Bucket bucket = new Bucket();

            //Act
            bucket.Content = content;

            //Assert
            Assert.AreEqual(bucket.Content, 0);
        }

        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        [Test]
        public void Bucket_MaximumCapacity_CapacitySetToDefault(int addToMax)
        {
            //Arrange and Act
            Bucket bucket = new Bucket(Bucket.MAX_CAPACITY + addToMax);

            //Assert
            Assert.AreEqual(bucket.Capacity, Bucket.DEFAULT_CAPACITY);
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [Test]
        public void Bucket_ReadCapacity_ReadsCapacitySuccesfully(int capacity)
        {
            //Arange and Act
            Bucket bucket = new Bucket(capacity);

            //Assert
            Assert.AreEqual(bucket.Capacity, capacity);
        }

        [Test]
        public void Bucket_ReadContent_ContentShouldReadZero()
        {
            //Arrange and Act
            Bucket bucket = new Bucket();

            //Assert
            Assert.AreEqual(bucket.Content, 0);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Bucket_SetContent_ContentSetSuccesfully(int content)
        {
            //Arrange
            Bucket bucket = new Bucket();

            //Act
            bucket.Content = content;

            //Assert
            Assert.AreEqual(bucket.Content, content);
        }

        [Test]
        public void Bucket_DefaultCapacity_ShouldBeDefaultCapacity()
        {
            //Arrange and Act
            Bucket bucket = new Bucket();

            //Assert
            Assert.AreEqual(bucket.Capacity, Bucket.DEFAULT_CAPACITY);
        }

        [TestCase(9)]
        [TestCase(5)]
        [TestCase(1)]
        [Test]
        public void Bucket_MinimumCapacity_CapacitySetToDefault(int capacity)
        {
            //Arrange and Act
            Bucket bucket = new Bucket(capacity);

            //Assert
            Assert.AreEqual(bucket.Capacity, Bucket.DEFAULT_CAPACITY);
        }
    }
}

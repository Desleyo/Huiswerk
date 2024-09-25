using Week3B_Emmer.Models;

namespace Week3B_Emmer_UnitTests.BucketTests.Methods
{
    internal class BucketMethodTests
    {
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Fill_AddContent_ContentAddedSuccesfully(int amount)
        {
            //Arrange
            Bucket bucket = new Bucket();

            //Act
            bucket.Fill(amount);

            //Assert
            Assert.AreEqual(bucket.Content, amount);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Empty_RemoveContent_ContentRemovedSuccesfully(int amount)
        {
            //Arrange
            Bucket bucket = new Bucket();

            //Act
            int currentContent = Bucket.DEFAULT_CAPACITY;
            bucket.Content = currentContent;
            bucket.Empty(amount);

            //Assert
            Assert.AreEqual(bucket.Content, currentContent - amount);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Empty_RemoveAllContent_BucketIsEmpty(int content)
        {
            //Arrange
            Bucket bucket = new Bucket();

            //Act
            bucket.Content = content;
            bucket.Empty();

            //Assert
            Assert.AreEqual(bucket.Content, 0);
        }

        [TestCase(20, 10)]
        [TestCase(50, 20)]
        [TestCase(100, 40)]
        [Test]
        public void CombineBuckets_CombiningBuckets_BucketsAreCombined(int capacity, int content)
        {
            //Arrange
            Bucket bucket1 = new Bucket(capacity);
            Bucket bucket2 = new Bucket(capacity);

            //Act
            bucket1.Content = content;
            bucket2.Content = content;
            bucket1.CombineBuckets(bucket2);

            //Assert
            Assert.AreEqual(bucket1.Content, content * 2);
            Assert.AreEqual(bucket2.Content, 0);
        }
    }
}

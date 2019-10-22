using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance.Tests
{
    [TestClass]
    public class PersonPrinterTests
    {
        [TestMethod]
        public void PersonGetsPrinted()
        {
            // Arrange
            var item = new TestItem { Name = "Test Item" };

            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream))
                {
                    // Act
                    Printer.Print(item, writer);
                    writer.Flush();

                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    // Assert
                    using (var reader = new StreamReader(stream))
                    {
                        var lineWritten = reader.ReadLine();
                        Assert.AreEqual("Test Item", lineWritten);
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSize_ThrowsException()
        {
            Television television = new Television
            {
                Manufacturer = "Samsung"
            };
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(television, writer);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptySize_ThrowsException()
        {
            Television television = new Television
            {
                Manufacturer = "Samsung",
                Size = ""
            };
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(television, writer);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullManufaturer_ThrowsException()
        {
            Television television = new Television
            {
                Size = "24"
            };
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(television, writer);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyManufacturer_ThrowsException()
        {
            Television television = new Television
            {
                Manufacturer = "",
                Size = "24"
            };
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(television, writer);
                }
            }
        }

        [TestMethod]
        public void TelevisionSuccessfullyPrinted()
        {
            Television television = new Television
            {
                Manufacturer = "Samsung",
                Size = "24"
            };
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(television, writer);
                    writer.Flush();
                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(stream))
                    {
                        var givenLine = reader.ReadLine();
                        Assert.AreEqual("Samsung - 24", givenLine);
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullBrand_ThrowsException()
        {
            Food food = new Food
            {
                Upc = "12345"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(food, writer);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyBrand_ThrowsException()
        {
            Food food = new Food
            {
                Upc = "12345",
                Brand = ""
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(food, writer);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUpc_ThrowsException()
        {
            Food food = new Food
            {
                Brand = "Kirkland"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(food, writer);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyUpc_ThrowsException()
        {
            Food food = new Food
            {
                Upc ="",
                Brand = "Kirkland"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(food, writer);
                }
            }
        }

        [TestMethod]
        public void FoodSuccessfullyPrinted()
        {
            Food food = new Food
            {
                Upc = "12345",
                Brand = "Kirkland"
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    Printer.Print(food, writer);
                    writer.Flush();
                    stream.Position = 0;
                    stream.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(stream))
                    {
                        var givenLine = reader.ReadLine();
                        Assert.AreEqual("12345 - Kirkland", givenLine);
                    }
                }
            }
        }



    }

    public class TestItem : Item {
        public string Name { get; set; }
        public override string PrintInfo()
        {
            return Name;
        }
    }
}

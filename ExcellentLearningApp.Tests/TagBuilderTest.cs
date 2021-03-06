﻿using ExcellentLearningApp.Infrastructure;
using System.Collections.Generic;
using Xunit;

namespace ExcellentLearningApp.Tests
{
    public class TagBuilderTest
    {
        [Fact]
        public void Should_BuildHtmlTreeWithoutAttributes()
        {
            // Arrange
            var tagBuilder = new TagBuilder("html");
            tagBuilder.SetIntendSize(5);

            // Act
            var result = tagBuilder
                .AddChild("ul", "sample")
                .AddChild("p", "Laland")
                .ToString();

            // Assert
            Assert.Equal("<html>\r\n     <ul>\r\n          sample\r\n     </ul>\r\n     <p>\r\n          Laland\r\n     </p>\r\n</html>\r\n", result);
        }

        [Fact]
        public void Should_BuildHtmlTreeWithAttributes()
        {
            // Arrange
            var tagBuilder = new TagBuilder(name: "div", attributes: new List<(string, string)> { ("class", "container") });
            tagBuilder.SetIntendSize(5);

            // Act
            var result = tagBuilder
                .AddChild(name: "input", text: "Login")
                .AddChild(name: "button", attributes: new List<(string, string)> { ("disabled", ""), ("class", ".btn") })
                .ToString();

            // Assert
            Assert.Equal("<div class=\"container\">\r\n     <input>\r\n          Login\r\n     </input>\r\n     <button disabled class=\".btn\" />\r\n</div>\r\n", result);
        }

        [Fact]
        public void Should_BuildNestedHtmlTaree()
        {
            // Arrange
            var tagMainBuilder = new TagBuilder(name: "div", attributes: new List<(string, string)> { ("class", "container") });
            var tagSubBuilder = new TagBuilder(name: "div", attributes: new List<(string, string)> { ("class", "input-wrapper") });

            // Act
            var newElement = tagSubBuilder
                .AddChild(name: "label", text: "sample")
                .AddChild(name: "input")
                .Build();
            var result = tagMainBuilder
                .AddChild(newElement)
                .ToString();

            // Assert
            Assert.Equal("<div class=\"container\">\r\n  <div class=\"input-wrapper\">\r\n    <label>\r\n      sample\r\n    </label>\r\n    <input />\r\n  </div>\r\n</div>\r\n", result);
        }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Statiq.Common
{
    /// <summary>
    /// Extensions to make it easier to get typed information from metadata.
    /// </summary>
    public static class IMetadataConversionExtensions
    {
        /// <summary>
        /// Gets the value for the specified key converted to a string. This method never throws an exception. It will return the specified
        /// default value if the key is not found.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to a string.</param>
        /// <returns>The value for the specified key converted to a string or the specified default value.</returns>
        public static string GetString(this IMetadata metadata, string key, string defaultValue = null) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Formats a string value if it exists in the metadata, otherwise returns a default value.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="formatFunc">A formatting function to apply to the string value of the specified key.</param>
        /// <param name="defaultValue">The default value to use if the key is not found.</param>
        /// <returns>The formatted value of the specified key if it exists or the specified default value.</returns>
        public static string GetString(this IMetadata metadata, string key, Func<string, string> formatFunc, string defaultValue = null) =>
            metadata.ContainsKey(key) ? formatFunc(metadata.GetString(key)) : defaultValue;

        /// <summary>
        /// Gets the value for the specified key converted to a bool. This method never throws an exception. It will return the specified
        /// default value if the key is not found.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to a bool.</param>
        /// <returns>The value for the specified key converted to a bool or the specified default value.</returns>
        public static bool GetBool(this IMetadata metadata, string key, bool defaultValue = false) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Gets the value for the specified key converted to an int. This method never throws an exception. It will return the specified
        /// default value if the key is not found.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to an int.</param>
        /// <returns>The value for the specified key converted to an int or the specified default value.</returns>
        public static int GetInt(this IMetadata metadata, string key, int defaultValue = 0) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Gets the value for the specified key converted to a <see cref="GetDateTime"/>. This method never throws an exception. It will return the specified
        /// default value if the key is not found.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to a <see cref="GetDateTime"/>.</param>
        /// <returns>The value for the specified key converted to a <see cref="GetDateTime"/> or the specified default value.</returns>
        public static DateTime GetDateTime(this IMetadata metadata, string key, DateTime defaultValue = default(DateTime)) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Gets the value for the specified key converted to a <see cref="GetFilePath"/>. This method never throws an exception. It will
        /// return the specified default value if the key is not found or if the string value can't be converted to a <see cref="GetFilePath"/>.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to a <see cref="GetFilePath"/>.</param>
        /// <returns>The value for the specified key converted to a <see cref="GetFilePath"/> or the specified default value.</returns>
        public static FilePath GetFilePath(this IMetadata metadata, string key, FilePath defaultValue = null) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Gets the value for the specified key converted to a <see cref="GetDirectoryPath"/>. This method never throws an exception. It will
        /// return the specified default value if the key is not found or if the string value can't be converted to a <see cref="GetDirectoryPath"/>.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to a <see cref="GetDirectoryPath"/>.</param>
        /// <returns>The value for the specified key converted to a <see cref="GetDirectoryPath"/> or the specified default value.</returns>
        public static DirectoryPath GetDirectoryPath(this IMetadata metadata, string key, DirectoryPath defaultValue = null) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Gets the value for the specified key converted to a <see cref="IReadOnlyList{T}"/>. This method never throws an exception. It will return the specified
        /// default value if the key is not found. Note that if the value is atomic, the conversion operation will succeed and return a list with one item.
        /// </summary>
        /// <typeparam name="T">The type to convert to.</typeparam>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to a list.</param>
        /// <returns>The value for the specified key converted to a list or the specified default value.</returns>
        public static IReadOnlyList<T> GetList<T>(this IMetadata metadata, string key, IReadOnlyList<T> defaultValue = null) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Gets the value for the specified key converted to a <see cref="IDocument"/>. This method never throws an exception.
        /// It will return null if the key is not found.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the document to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to a document.</param>
        /// <returns>The value for the specified key converted to a string or null.</returns>
        public static IDocument GetDocument(this IMetadata metadata, string key, IDocument defaultValue = null) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Gets the value for the specified key converted to a <c>IReadOnlyList&lt;IDocument&gt;</c>. This method never throws an exception.
        /// It will return null if the key is not found and an empty list if the key is found but contains no items that can be converted to <see cref="IDocument"/>.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the documents to get.</param>
        /// <param name="defaultValue">The default value to use if the key is not found or cannot be converted to a document list.</param>
        /// <returns>The value for the specified key converted to a list or null.</returns>
        public static IReadOnlyList<IDocument> GetDocumentList(this IMetadata metadata, string key, IReadOnlyList<IDocument> defaultValue = null) => metadata.Get(key, defaultValue);

        /// <summary>
        /// Gets the value associated with the specified key as a dynamic object. This is equivalent
        /// to calling <c>as dynamic</c> to cast the value.
        /// </summary>
        /// <param name="metadata">The metadata containing the value.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value to use if either the key is not found or the
        /// underlying value is null (since the dynamic runtime binder can't bind null values).</param>
        /// <returns>A dynamic value for the specific key or default value.</returns>
        public static dynamic GetDynamic(this IMetadata metadata, string key, object defaultValue = null) => metadata.Get(key, defaultValue) ?? defaultValue;
    }
}

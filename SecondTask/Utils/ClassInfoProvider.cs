namespace SecondTask.Utils
{
    /// <summary>
    /// Провайдер для предоставления информации о классе.
    /// </summary>
    internal static class ClassInfoProvider
    {
        /// <summary>
        /// Определяет и возвращает строку, описывающую отношение между двумя классами.
        /// </summary>
        /// <param name="firstObject">Первый объект для сравнения.</param>
        /// <param name="secondObject">Второй объект для сравнения.</param>
        /// <returns>Строка, описывающая отношение между классами.</returns>
        /// <exception cref="ArgumentNullException">Если хотя бы один из объектов равен null.</exception>
        /// <exception cref="ArgumentException">Если хотя бы один из объектов не является экземпляром класса или если отношение не может быть определено.</exception>
        internal static string GetClassRelationInfo(object firstObject, object secondObject)
        {
            EnsureObjectsNotNull(firstObject, secondObject);

            Type firstObjectType = firstObject.GetType();
            Type secondObjectType = secondObject.GetType();

            EnsureTypeIsClass(firstObjectType, nameof(firstObject));
            EnsureTypeIsClass(secondObjectType, nameof(secondObject));

            return DetermineRelation(firstObjectType, secondObjectType);
        }

        /// <summary>
        /// Определяет и возвращает строку, описывающую отношение между двумя типами классов.
        /// </summary>
        /// <param name="firstObjectType">Тип первого объекта.</param>
        /// <param name="secondObjectType">Тип второго объекта.</param>
        /// <returns>Строка, описывающая отношение между классами.</returns>
        /// <exception cref="ArgumentException">Если отношение между классами не может быть определено.</exception>
        private static string DetermineRelation(Type firstObjectType, Type secondObjectType)
        {
            if (firstObjectType.IsSubclassOf(secondObjectType))
            {
                return $"Класс {firstObjectType.Name} является предком класса {secondObjectType.Name}.";
            }

            if (secondObjectType.IsSubclassOf(firstObjectType))
            {
                return $"Класс {secondObjectType.Name} является предком класса {firstObjectType.Name}.";
            }

            if (firstObjectType == secondObjectType)
            {
                return $"Оба переданных объекта являются экземплярами класса {firstObjectType.Name}.";
            }

            throw new ArgumentException("Степень родства между классами не может быть определена.");
        }

        /// <summary>
        /// Проверяет, что переданные объекты не равны null.
        /// </summary>
        /// <param name="firstObject">Первый объект.</param>
        /// <param name="secondObject">Второй объект.</param>
        /// <exception cref="ArgumentNullException">Если один из объектов равен null.</exception>
        private static void EnsureObjectsNotNull(object firstObject, object secondObject)
        {
            _ = firstObject ?? throw new ArgumentNullException(nameof(firstObject), "Объект не должен быть null.");
            _ = secondObject ?? throw new ArgumentNullException(nameof(secondObject), "Объект не должен быть null.");
        }

        /// <summary>
        /// Проверяет, что переданный тип является классом.
        /// </summary>
        /// <param name="objectType">Тип объекта для проверки.</param>
        /// <param name="paramName">Имя параметра для сообщения об ошибке.</param>
        /// <exception cref="ArgumentException">Если тип не является классом.</exception>
        private static void EnsureTypeIsClass(Type objectType, string paramName)
        {
            if (!objectType.IsClass)
            {
                throw new ArgumentException($"Обьект {paramName} не является экземпляром класса, тип - {objectType}.", paramName);
            }
        }
    }
}

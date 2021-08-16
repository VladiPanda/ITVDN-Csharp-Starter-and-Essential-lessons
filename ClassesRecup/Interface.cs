﻿using System;

namespace ClassesRecup
{
    public interface Interface
    {
        // Интерфейс можно сравнить с абстрактным классом у которого нет реализации, а только абстрактные методы
        
        // Задача интерфейса определить контракт взаимодействия между классами, другими словами с помощью
        // интерфейса мы определяем поведение которое в последствии будет реализованно в каком-то конкретном классе
        
        // Важное отличие интерфейса от класса(в том числе абстрактного),
        // что они позволяют делать множественное наследование
        
        // Когда мы говорим, что класс наследуется от интерфейса, правильнее говорить, что класс реализует интерфейс
    }

    interface IDataProvider
    {
        // Интерфейс != класс, в нем не может быть конструктором(в отличие от абстрактного класса)
        // Экземпляр интерфейса мы создать не можем(в абстрактном классе тоже)
        // Интерфейс не можем содержать поля класса(но свойства может),
        // связано это с тем, что интерфейс должен описывать поведение и контракт
        // но не должен содержать какую-то конкретную реализацию

        string GetData(); // по-умолчанию все члены интерфейса public
    }

    interface IDataProcessor
    {
        void ProcessData(IDataProvider dataProvider);
    }

    class ConsoleDataProcessor : IDataProcessor
    {
        // Если мы реализуем в каком-то классе интерфейс, мы должны внутри класса реализовать все его компоненты
        // Это делается для того, чтобы в последствии когда мы обращались к ссылке такого интерфейса мы могли вызвать
        // любой из методов который в этом интерфейсе есть и класс который мы поместили в эту ссылку гарантированно этот
        // метод реализовывал (его можно вызвать и с ним можно работать)
        public void ProcessData(IDataProvider dataProvider)
        {
            Console.WriteLine(dataProvider.GetData());
        }
    }

    class DbDataProvider: IDataProvider
    {
        public string GetData()
        {
            return "Данные из БД";
        }
    }

    class FileDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Данные из файла";
        }
    }

    class APIDataProvider: IDataProvider
    {
        public string GetData()
        {
            return "Данные из API";
        }
    }
}
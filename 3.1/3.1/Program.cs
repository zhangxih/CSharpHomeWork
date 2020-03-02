﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1
{
    public interface Shape
    {
        double GetArea();
        bool Legal();
    }

    public class ShapeFactory
    {
        private Shape shape = null;
        public Shape CreateRandomShape()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iSeed);
            while (true)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        shape = new Oblong(random.Next(1, 100), random.Next(1, 100));
                        break;
                    case 2:
                        shape = new Square(random.Next(1, 100));
                        break;
                    case 3:
                        shape = new Triangle(random.Next(1, 100), random.Next(1, 100));
                        break;
                    default:
                        break;
                }
                if (shape.Legal())
                    break;
            }
            return shape;
        }
    }

        public class Oblong:Shape
    {
        private int width;
        private int height;
        public Oblong(int width,int height)
        {
            this.width = width;
            this.height = height;
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public double GetArea()
        {
            return width * height;
        }
        public bool Legal()
        {
            return (width != height && width > 0 && height > 0);
        }
    }

    public class Square : Shape
    {
        private int width;
        private int height;
        public Square(int width)
        {
            this.width = width;
            this.height = width;
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                height = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                width = value;
                height = value;
            }
        }
        public double GetArea()
        {
            return width * height;
        }
        public bool Legal()
        {
            return (width == height && width > 0 && height > 0);
        }
    }

    public class Triangle : Shape
    {
        private int width;
        private int height;
        public Triangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public double GetArea()
        {
            return width * height*0.5;
        }
        public bool Legal()
        {
            return (width > 0 && height > 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double totalArea = 0;
            Shape[] shape = new Shape[10];
            ShapeFactory shapeFactory = new ShapeFactory();
            for (int i = 0; i < 10; i++)
            {
                shape[i] = shapeFactory.CreateRandomShape();
                Console.WriteLine(
                    $"第{i+1}个图案为{shape[i].GetType().Name},面积为{shape[i].GetArea()}"
                    );
                totalArea += shape[i].GetArea();
            }
            Console.Write($"总面积为{totalArea}");
        }
    }
}

﻿using Com.Aurora.AuWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Com.Aurora.Shared.Helpers;

namespace Com.Aurora.AuWeather.Effects
{
    // 简单雨滴是一个矩形，从画布顶部出发，以一个固定角度和初速度，以 g(?) 的加速度下落，同时，雨滴纹理的旋转角度应与运动方向相同
    // 下落到画布底部后，粒子被回收。同时，上方的出发位置是随机的，雨的规模(计算加速度、速度、缩放和角度)可以被用户设置
    public class RainParticleSystem : ParticleSystem
    {
        private RainLevel rainLevel;

        /// <summary>
        /// 根据雨的规模设置初始化参数
        /// </summary>
        /// <param name="rainLevel"></param>
        public RainParticleSystem(RainLevel rainLevel)
        {
            this.rainLevel = rainLevel;
            this.InitializeConstants();
        }
        protected override void InitializeConstants()
        {
            bitmapFilename = "Assets/rain.png";
            minLifetime = 0;
            maxLifetime = 0;
            minRotationSpeed = 0;
            maxRotationSpeed = 0;
            switch (rainLevel)
            {
                case RainLevel.light:
                    InitializeLight();
                    break;
                case RainLevel.moderate:
                    Initializemoderate();
                    break;
                case RainLevel.heavy:
                    Initializeheavy();
                    break;
                case RainLevel.extreme:
                    Initializeextreme();
                    break;
                default:
                    break;
            }
            blendState = Microsoft.Graphics.Canvas.CanvasBlend.SourceOver;
        }

        private void Initializeextreme()
        {
            minRotationAngle = 1.5708f;
            maxRotationAngle = 1.5708f;

            minInitialSpeed = 1200;
            maxInitialSpeed = 2000;

            minAcceleration = 800;
            maxAcceleration = 1500;

            minScale = 0.9f;
            maxScale = 6;

            minNumParticles = 0;
            maxNumParticles = 12;
        }

        private void Initializeheavy()
        {
            minRotationAngle = 1.54f;
            maxRotationAngle = 1.57f;

            minInitialSpeed = 900;
            maxInitialSpeed = 1600;

            minAcceleration = 600;
            maxAcceleration = 1000;

            minScale = 0.9f;
            maxScale = 4;

            minNumParticles = 0;
            maxNumParticles = 8;
        }

        private void Initializemoderate()
        {
            minRotationAngle = 1.45f;
            maxRotationAngle = 1.52f;

            minInitialSpeed = 700;
            maxInitialSpeed = 1200;

            minAcceleration = 400;
            maxAcceleration = 800;

            minScale = 0.8f;
            maxScale = 3;

            minNumParticles = 0;
            maxNumParticles = 4;
        }

        private void InitializeLight()
        {
            minRotationAngle = 1.404f;
            maxRotationAngle = 1.484f;

            minInitialSpeed = 400;
            maxInitialSpeed = 950;

            minAcceleration = 100;
            maxAcceleration = 600;

            minScale = 0.8f;
            maxScale = 2;

            minNumParticles = 0;
            maxNumParticles = 2;
        }

        /// <summary>
        /// 根据旋转角度确定下落角度
        /// </summary>
        /// <returns></returns>
        private Vector2 PickDirection(float angle)
        {
            return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        /// <summary>
        /// 更新粒子物理属性，如果粒子超过边界，将其回收
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <param name="size"></param>
        public void Update(float elapsedTime, Vector2 size)
        {
            for (int i = ActiveParticles.Count - 1; i >= 0; i--)
            {
                var p = ActiveParticles[i];
                if (p.Position.X <= size.X && p.Position.Y <= size.Y)
                {
                    p.Update(elapsedTime);
                }
                else
                {
                    ActiveParticles.RemoveAt(i);
                    FreeParticles.Push(p);
                }
            }
        }

        /// <summary>
        /// 获得画布尺寸，在画布顶部生成粒子
        /// </summary>
        /// <param name="Size"></param>
        public void AddRainDrop(Vector2 Size)
        {
            int numParticles = Tools.Random.Next(minNumParticles, maxNumParticles);
            float x = Tools.RandomBetween(0 - Size.Y * (float)Math.Tan(1.5708 - (minRotationAngle + maxRotationAngle) / 2), Size.X);
            for (int i = 0; i < numParticles; i++)
            {
                Particle particle = (FreeParticles.Count > 0) ? FreeParticles.Pop() : new Particle();
                InitializeParticle(particle, new Vector2(x, -5));
                ActiveParticles.Add(particle);
            }
        }

        protected override void InitializeParticle(Particle particle, Vector2 where)
        {
            float velocity = Tools.RandomBetween(minInitialSpeed, maxInitialSpeed);
            float acceleration = Tools.RandomBetween(minAcceleration, maxAcceleration);
            float lifetime = Tools.RandomBetween(minLifetime, maxLifetime);
            float scale = Tools.RandomBetween(minScale, maxScale);
            float rotationSpeed = Tools.RandomBetween(minRotationSpeed, maxRotationSpeed);
            float rotation = Tools.RandomBetween(minRotationAngle, maxRotationAngle);
            Vector2 direction = PickDirection(rotation);
            particle.Initialize(where, velocity * direction, acceleration * direction, lifetime, scale, rotation, rotationSpeed);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathForGamesDemo;
using Raylib_cs;
using MathLibrary;



namespace pong
{
    internal class Game
    {

      
            int count = 0;
        private float _rotation1 = 0f;
        private float _rotation2 = 0f;
        private float _speed = 0.05f;
        private Matrix3 _position1;
        private Matrix3 _position2;
        private Vector2 _ball;
        private Vector2 _ballVelocity;


        
        public void Run()
        {
            _position1.m00 = 50;  
            _position1.m22 = 400; 

            _position2.m00 = 1150; 
            _position2.m22 = 400; 

            Raylib.InitWindow(1200, 800, "Hello World");


            //pos for both blocks
            
            _ball = new Vector2(400, 500);
            _ballVelocity = new Vector2(0.05f, 0.05f);
            while (!Raylib.WindowShouldClose())
            {
               
                
                movementInput();
                Update();



                

                Raylib.ClearBackground(Color.Black);

                

                Raylib.DrawRectangle(600, 0, 1, 800, Color.White);
            Raylib.DrawText("bounce count" + count.ToString(), 450, 0, 10, Color.White);
                

                Raylib.DrawCircle((int)_ball.x, (int)_ball.y, 6, Color.Pink);
                Raylib.DrawRectangle((int)_position1.m00, (int)_position1.m22, 5, 150, Color.White);
                Raylib.DrawRectangle((int)_position2.m00, (int)_position2.m22, 5, 150, Color.White);
                Raylib.EndDrawing();



            }
        }

        private void movementInput()
        {
            if (Raylib.IsKeyDown(KeyboardKey.W))
                _position1.m22 -= _speed;
            if (Raylib.IsKeyDown(KeyboardKey.S))
                _position1.m22 += _speed;
          
            
            
            if (Raylib.IsKeyDown(KeyboardKey.Up))
                _position2.m22 -= _speed;
            if (Raylib.IsKeyDown(KeyboardKey.Down))
                _position2.m22 += _speed;


            //clamps so they stop flying away
            _position1.m22= Math.Clamp(_position1.m22, 0, Raylib.GetScreenHeight() - 100);
            _position2.m22 = Math.Clamp(_position2.m22, 0, Raylib.GetScreenHeight() - 100);
        }


        public void Update()
        {
            _ball.x += _ballVelocity.x;
            _ball.y += _ballVelocity.y;

            // collides with top or bottom
            if (_ball.y <= 0 || _ball.y >= Raylib.GetScreenHeight())
            {
                _ballVelocity.y = -_ballVelocity.y;
                count++;
            }

            // collides with left side
            if (_ball.x <= _position1.m00 + 5 && _ball.y >= _position1.m22 && _ball.y <= _position1.m22 + 150)
            {
                _ballVelocity.x = -_ballVelocity.x;  // invert horizontal direction
                count++;
            }

            //collides with right side
            if (_ball.x >= _position2.m00- 10 && _ball.y >= _position2.m22 && _ball.y <= _position2.m22 + 150)
            {
                _ballVelocity.x = -_ballVelocity.x;  // invert horizontal direction
                count++;
            }

          

            
            if (_ball.x <= 0 || _ball.x >= Raylib.GetScreenWidth())
            {
                
                if (_ball.x <= 0 || _ball.x >= Raylib.GetScreenWidth())
                {
                    Raylib.CloseWindow(); 
                }




            }
        }
        public void End()
        {
            Raylib.EndDrawing();
        }
    }
}
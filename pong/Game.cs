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
        
        private float _speed = 0.05f;
        private Matrix3 _position1;
        private Matrix3 _position2;
        private Matrix3 _ball;
        private Vector2 _ballVelocity;


        
        public void Run()
        {
            _position1.m00 = 50;  
            _position1.m22 = 400; 

            _position2.m00 = 1150; 
            _position2.m22 = 400; 

            Raylib.InitWindow(1200, 800, "Hello World");


            //pos for both blocks
            
            

            _ball.m00 = 400;
            _ball.m22 = 500;
            _ballVelocity = new Vector2(0.0005f, 0.05f);
            while (!Raylib.WindowShouldClose())
            {
               
                
                movementInput();
                Update();



                

                Raylib.ClearBackground(Color.Black);

                

                Raylib.DrawRectangle(600, 0, 1, 800, Color.White);
            Raylib.DrawText("bounce count" + count.ToString(), 450, 0, 10, Color.White);
                

                Raylib.DrawCircle((int)_ball.m00, (int)_ball.m22, 6, Color.Pink);
                Raylib.DrawRectangle((int)_position1.m00 , (int)_position1.m22, 5, 150, Color.White);
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
            _position1.m22= Math.Clamp(_position1.m22, 0, Raylib.GetScreenHeight() - 150);
            _position2.m22 = Math.Clamp(_position2.m22, 0, Raylib.GetScreenHeight() - 150);
        }


        public void Update()
        {
            _ball.m00 += _ballVelocity.x;
            _ball.m22 += _ballVelocity.y;

            // collides with top or bottom
            if (_ball.m22 <= 0 || _ball.m22 >= Raylib.GetScreenHeight())
            {
                _ballVelocity.y = -_ballVelocity.y;
                count++;
            }

            // collides with left side
            if (_ball.m00 <= _position1.m00 + 5 && _ball.m22 >= _position1.m22 && _ball.m22 <= _position1.m22 + 150)
            {
                _ballVelocity.x = -_ballVelocity.x;  // invert horizontal direction
                count++;
            }

            //collides with right side
            if (_ball.m00 >= _position2.m00- 10 && _ball.m22 >= _position2.m22 && _ball.m22 <= _position2.m22 + 150)
            {
                _ballVelocity.x = -_ballVelocity.x;  // invert horizontal direction
                count++;
            }

          

            
            if (_ball.m00 <= 0 || _ball.m00 >= Raylib.GetScreenWidth())
            {
                
                if (_ball.m00 <= 0 || _ball.m00 >= Raylib.GetScreenWidth())
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
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace pong
{
    internal class Game
    {
      
            int count = 0;
        private float _speed = 0.05f;
        private Vector2 _position1;
        private Vector2 _position2;
        private Vector2 _ball;
        private Vector2 _ballVelocity;
         
       
        
        public void Run()
        {

            
            Raylib.InitWindow(1200, 800, "Hello World");


            //pos for both blocks
            _position1 = new Vector2(100, 400);
            _position2 = new Vector2(1100, 400);
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
                Raylib.DrawRectangle((int)_position1.x, (int)_position1.y, 5, 50, Color.White);
                Raylib.DrawRectangle((int)_position2.x, (int)_position2.y, 5, 50, Color.White);
                Raylib.EndDrawing();



            }
        }

        private void movementInput()
        {
            if (Raylib.IsKeyDown(KeyboardKey.W))
                _position1.y -= _speed;
            if (Raylib.IsKeyDown(KeyboardKey.S))
                _position1.y += _speed;

            if (Raylib.IsKeyDown(KeyboardKey.Up))
                _position2.y -= _speed;
            if (Raylib.IsKeyDown(KeyboardKey.Down))
                _position2.y += _speed;


            //clamps so they stop flying away
            _position1.y = Math.Clamp(_position1.y, 0, Raylib.GetScreenHeight() - 50);
            _position2.y = Math.Clamp(_position2.y, 0, Raylib.GetScreenHeight() - 50);
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
            if (_ball.x <= _position1.x + 5 && _ball.y >= _position1.y && _ball.y <= _position1.y + 50)
            {
                _ballVelocity.x = -_ballVelocity.x;  // invert horizontal direction
                count++;
            }

            //collides with right side
            if (_ball.x >= _position2.x - 10 && _ball.y >= _position2.y && _ball.y <= _position2.y + 50)
            {
                _ballVelocity.x = -_ballVelocity.x;  // invert horizontal direction
                count++;
            }

          //add to see how many time the ball bounces

            // ball goes out of bounds
            if (_ball.x <= 0 || _ball.x >= Raylib.GetScreenWidth())
            {
                // If the ball misses both paddles, exit the game
                if (_ball.x <= 0 || _ball.x >= Raylib.GetScreenWidth())
                {
                    Raylib.CloseWindow(); // Close the game window
                }




            }
        }
        public void End()
        {
            Raylib.EndDrawing();
        }
    }
}
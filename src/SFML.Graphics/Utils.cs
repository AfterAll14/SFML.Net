using System;
using SFML.System;

namespace SFML.Graphics
{
    public static class VectorExtensions
    {
        public static float GetLength(this Vector2f vector)
        {
            return (float)Math.Pow(vector.X * vector.X + vector.Y * vector.Y, 0.5);
        }

        public static Vector2f Vector2f(this Vector2u vector)
        {
            return new Vector2f(vector.X, vector.Y);
        }
    }

    public enum TextHorizontalAlignment
    {
        Center = 50,
        Left = 0,
        Right = 100
    }

    public enum TextVerticalAlignment
    {
        Center = 50,
        Bottom = 0,
        Top = 100
    }

    public static class DrawingUtils
    {
        static Text text = new Text();
        static RectangleShape rectangleShape = new RectangleShape(new Vector2f(1, 1));

        public static void DrawText(RenderTarget renderTarget, string displayedString, Vector2f position, Font font, Color color, uint characterSize, TextHorizontalAlignment horizontalAlignment = TextHorizontalAlignment.Center, TextVerticalAlignment verticalAlignment = TextVerticalAlignment.Center)
        {
            text.DisplayedString = displayedString;
            text.Font = font;
            text.Color = color;
            text.CharacterSize = characterSize;

            FloatRect bounds = text.GetLocalBounds();
            float offsetX = -(float)horizontalAlignment / 100.0f * bounds.Width;
            float offsetY = -(float)verticalAlignment / 100.0f * bounds.Height;
            Vector2f alignmentOffset = new Vector2f(offsetX, offsetY);
            text.Position = position + alignmentOffset;


            renderTarget.Draw(text);
        }

        public static void DrawLine(RenderTarget renderTarget, Vector2f start, Vector2f end, float thickness, Color color)
        {
            Vector2f direction = end - start;

            rectangleShape.Position = start;
            rectangleShape.Rotation = (float)Math.Atan2(direction.Y, direction.X) * 180.0f / (float)Math.PI;
            rectangleShape.Size = new Vector2f(direction.GetLength(), thickness);
            rectangleShape.Origin = new Vector2f(0.0f, thickness * 0.5f);
            rectangleShape.FillColor = color;

            renderTarget.Draw(rectangleShape);
        }
    }
}
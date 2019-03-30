
using PixelVision8.Engine;
using PixelVision8.Engine.Chips;
using PixelVision8.Runner.Parsers;

namespace PixelVision8.Runner.Exporters
{
    public class FontExporter : SpriteExporter
    {

        public FontExporter(string fileName, IEngine engine, IImageExporter imageExporter): base(fileName, engine, imageExporter)
        {
            
        }
        
        // TODO this should be a step in the exporter
        public override void ConfigurePixelData()
        {
            var spriteChip = engine.spriteChip;
            
            var width = 96;//spriteChip.textureWidth;
            var height = 64;//spriteChip.textureHeight;
            
            
            var textureData = new TextureData(width, height);
            
//            var pixelData = new int[width * height];
            
            // Go through all of the sprites in the font
            
            // TODO get font sprites

            var total = 96;

            var maxCol = width / spriteChip.width;

            var tmpPixelData = new int[spriteChip.width * spriteChip.height];
            
            for (int i = 0; i < total; i++)
            {

                var pos = engine.gameChip.CalculatePosition(i, maxCol);

                spriteChip.ReadSpriteAt(i, tmpPixelData);
                
                textureData.SetPixels(pos.X * spriteChip.width, pos.Y * spriteChip.height, spriteChip.width, spriteChip.height, tmpPixelData);

            }
            
            var colorMapChip = engine.GetChip(ColorMapParser.chipName, false) as ColorChip;

            var colors = colorMapChip == null ? engine.colorChip.colors : colorMapChip.colors;
            
            var imageExporter = new PNGWriter();
            
            exporter = new PixelDataExporter(fullFileName, textureData.pixels, width, height, colors, imageExporter);
            
        }
        
    }
}
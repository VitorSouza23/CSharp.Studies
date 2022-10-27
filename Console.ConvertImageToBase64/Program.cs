using static System.Console;

var imagePath = "images.jpeg";

byte[] imageArray = await File.ReadAllBytesAsync(imagePath, default);
string base64 = Convert.ToBase64String(imageArray);
WriteLine(base64);

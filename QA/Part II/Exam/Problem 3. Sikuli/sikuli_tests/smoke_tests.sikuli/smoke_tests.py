import unittest
bdLibPath=os.path.abspath(sys.argv[0]+"..")
if not bdLibPath in sys.path: sys.path.append(bdLibPath)
from _lib import *

class SmokeTests(unittest.TestCase):
    
    def setUp(self):
        pass
    
    def tearDown(self):
        pass    
    
    def test_001_DrawCircleInPaintAndSaveIt(self):
        circleRadius = 300
        RunApp("mspaint")
        sleep(4)
        click(Button.Oval, 5)
        click(Pattern(Area.Pallette).targetOffset(18,-30))
        dragDrop(Pattern(Area.Clipboard).targetOffset(0,50), Pattern(Area.Clipboard).targetOffset(circleRadius,50+circleRadius))
        sleep(2)
        click(Button.Save)
        sleep(2)
        type("circle.png")
        sleep(2)
        type(Key.ENTER)
        sleep(2)
        type(Key.F4, KeyModifier.ALT)
        sleep(2)

    def test_002_OpenFileInPaint(self):   
        RunApp("mspaint")
        sleep(4)
        type("o", KeyModifier.CTRL)
        sleep(2)
        type("circle.png")
        sleep(2)
        type(Key.ENTER)
        sleep(2)
        assert(exists(Assert.GreenCircle))
        sleep(2)
        type(Key.F4, KeyModifier.ALT)
        sleep(2)
    
if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SmokeTests)
    
    
    outfile = open("report.html", "w")
    runner = HTMLTestRunner.HTMLTestRunner(stream=outfile, title='SmokeTests Report' )
    runner.run(suite)
    outfile.close()
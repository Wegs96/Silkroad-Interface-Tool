using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SilkroadInterfaceTool.Base;

public class DesignArea : Canvas
{
    public enum CIFCursorType
    {
        Main,
        Hand,
        Resize,
    }

    private static readonly Dictionary<CIFCursorType, Cursor> _sroCursors = new();
    private readonly CIFMainFrame _mainFrame;
    private readonly MainWindow _mainWindow;

    public DesignArea(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        _mainFrame = new CIFMainFrame(this);
        _mainFrame.DefaultSetup();
        this.Children.Add(_mainFrame);

        // Setup the design area
        Background = Brushes.Aqua;
        SetupCursors();
        Cursor = GetCIFCursor(CIFCursorType.Main);
    }

    public CIFMainFrame MainFrame => _mainFrame;

    public static Cursor GetCIFCursor(CIFCursorType cursorType) =>
        _sroCursors.FirstOrDefault(p => p.Key == cursorType).Value;

    private void SetupCursors()
    {
        var mCur = Application.GetResourceStream(new Uri("Textures/Cursors/MainSroCursor.cur", UriKind.Relative));
        var hCur = Application.GetResourceStream(new Uri("Textures/Cursors/HandSroCursor.cur", UriKind.Relative));
        var rCur = Application.GetResourceStream(new Uri("Textures/Cursors/ResizeSroCursor.cur", UriKind.Relative));

        if (mCur != null)
            _sroCursors.Add(CIFCursorType.Main, new Cursor(mCur.Stream));
        if (hCur != null)
            _sroCursors.Add(CIFCursorType.Hand, new Cursor(hCur.Stream));
        if (rCur != null)
            _sroCursors.Add(CIFCursorType.Resize, new Cursor(rCur.Stream));

        mCur?.Stream.Dispose();
        hCur?.Stream.Dispose();
        rCur?.Stream.Dispose();
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SilkroadInterfaceTool.MVVM.Models.Helpers;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

// ReSharper disable InconsistentNaming

namespace SilkroadInterfaceTool.MVVM.Models;

public class ControlBase : Canvas, INotifyPropertyChanged
{
    protected ControlBase()
    {
        ContextMenu = new ContextMenu();
        Children.Add(new CResizer(this));
    }


    public event PropertyChangedEventHandler? PropertyChanged;


    public void SetCIFRectWidth(double width)
    {
        if (width < MinWidth) return;

        m_Rect.Width = width;
        Width = m_Rect.Width;
        OnPropertyChanged(nameof(CIFRect));
    }

    public void SetCIFRectHeight(double height)
    {
        if (height < MinHeight) return;

        m_Rect.Height = height;
        Height = m_Rect.Height;
        OnPropertyChanged(nameof(CIFRect));
    }

    /// <summary>
    /// Changes CIFRect X & Y to a given valeus
    /// transform param should be always false on dragging the control
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="transform"></param>
    public void SetCIFRectPosition(double x, double y, bool transform = false)
    {
        if ((int)CIFRect.X == (int)x && (int)CIFRect.Y == (int)y)
            return;

        //Debug.WriteLine("Old Pos: X:"+CIFRect.X + " Y:"+CIFRect.Y );

        m_Rect.X = x;
        m_Rect.Y = y;

        if (transform)
            this.RenderTransform = new TranslateTransform(x,
                y);

        OnPropertyChanged(nameof(CIFRect));
        // Debug.WriteLine("New Pos: X:"+CIFRect.X + " Y:"+CIFRect.Y );
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #region Private Properties

    private string m_Name = string.Empty;
    private CIFType m_type = CIFType.CIFUNKNOWN;
    private Rect m_ClientRect = new(0, 0, 0, 0);
    private Color m_Color = Color.FromArgb(255, 73, 102, 178);
    private string m_DDJ = string.Empty;
    private Color m_FontColor = Color.FromArgb(255, 254, 251, 216);
    private int m_FontIndex = 2;
    private int m_HAlign = 1;
    private int m_ID = 0;
    private Rect m_Rect = new(0, 0, 0, 0);
    private int m_Style = 0;
    private string m_SubSection = string.Empty;
    private string m_Text = string.Empty;
    private Point m_UV_LB = new(0, 1);
    private Point m_UV_LT = new(0, 0);
    private Point m_UV_RB = new(1, 1);
    private Point m_UV_RT = new(1, 0);
    private int m_VAlign = 1;

    #endregion

    #region Public Properties

    public Rect CIFClientRect
    {
        get => m_ClientRect;
        set
        {
            m_ClientRect = value;
            OnPropertyChanged();
        }
    }

    public Color CIFColor
    {
        get => m_Color;
        set
        {
            m_Color = value;
            OnPropertyChanged();
        }
    }

    public string CIFDDJ
    {
        get => m_DDJ;
        set
        {
            m_DDJ = value;
            OnPropertyChanged();
        }
    }

    public Color CIFFontColor
    {
        get => m_FontColor;
        set
        {
            m_FontColor = value;
            OnPropertyChanged();
        }
    }

    public int CIFFontIndex
    {
        get => m_FontIndex;
        set
        {
            m_FontIndex = value;
            OnPropertyChanged();
        }
    }

    public int CIFHAlign
    {
        get => m_HAlign;
        set
        {
            m_HAlign = value;
            OnPropertyChanged();
        }
    }

    public CIFType CIFType
    {
        get => m_type;
        set
        {
            m_type = value;
            OnPropertyChanged();
        }
    }

    public int CIFID
    {
        get => m_ID;
        set
        {
            m_ID = value;
            OnPropertyChanged();
        }
    }

    public Rect CIFRect
    {
        get => m_Rect;
        set
        {
            m_Rect = value;

            Width = value.Width;
            Height = value.Height;

            OnPropertyChanged();
        }
    }

    public int CIFStyle
    {
        get => m_Style;
        set
        {
            m_Style = value;
            OnPropertyChanged();
        }
    }

    public string CIFSubSection
    {
        get => m_SubSection;
        set
        {
            m_SubSection = value;
            OnPropertyChanged();
        }
    }


    public string CIFText
    {
        get => m_Text;
        set
        {
            m_Text = value;
            OnPropertyChanged();
        }
    }


    public string CIFName
    {
        get => m_Name;
        set
        {
            m_Name = value;
            OnPropertyChanged();
        }
    }

    public Point CIFUV_LB
    {
        get => m_UV_LB;
        set
        {
            m_UV_LB = value;
            OnPropertyChanged();
        }
    }

    public Point CIFUV_LT
    {
        get => m_UV_LT;
        set
        {
            m_UV_LT = value;
            OnPropertyChanged();
        }
    }

    public Point CIFUV_RB
    {
        get => m_UV_RB;
        set
        {
            m_UV_RB = value;
            OnPropertyChanged();
        }
    }

    public Point CIFUV_RT
    {
        get => m_UV_RT;
        set
        {
            m_UV_RT = value;
            OnPropertyChanged();
        }
    }

    public int CIFVAlign
    {
        get => m_VAlign;
        set
        {
            m_VAlign = value;
            OnPropertyChanged();
        }
    }

    #endregion
}
   M S B A M L   `   `   `  ????B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	   Q-clr-namespace:WpfApp2.Infrastructure.CommandsWpfApp2.Infrastructure.Commands  5   	   7 clr-namespace:WpfApp2.ViewModelsWpfApp2.ViewModels  5
   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #lclr-namespace:WpfApp2     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	   7cmd-clr-namespace:WpfApp2.Infrastructure.Commands  5   	   X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/  5	   	   )vm clr-namespace:WpfApp2.ViewModels  5
   	     ? 
ResizeMode$  NoResize=?5   	    ? WindowStyle$
 None=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ 1??5   	   $	??450??5   	   $	??800??5   	    ? 	Resources 5         SliderThumbStyle ?? 
TargetType ?? Property ?? Value ?? 
TargetType	 ?? Triggers
 P? Property P? Value ?? 
TargetName  SliderRepeatButton  SliderRepeatButton1 J? SnapsToDevicePixels  SliderThumb 
 Slider ? RowDefinitions ]?Name ]? DecreaseRepeatButton ]? Thumb ]? IncreaseRepeatButton  Horizontal_Slider ?? Triggers??%?	  &	        &	 ?    &	 ?    &	 .    &	 R    7  7  7  &	 ?    7  ?? 5      " n?6+   .?5   
   ??  ?@J?SnapsToDevicePixels$
 true??60   ?? 5   
    ?@?OverridesDefaultStyle$ false??62   ?? 5   
    ? ??$ 18??6#   ?? 5   
    ? ??$ 18??6"   ?? 5   
    ? ?? 5      ?? 5      " n?6"   .R?5      A? $??Ellipse??5      ???#9b59b6$??1??5      ???#9b59b65      	 5       P? 5!      
 ?@J?IsMouseOver$
 True??69   . ?5"      ?? $ Ellipse??6%    ? ??
 ? ???6J   5#      P? 5$      
 ? {?$ false??67   . ?5%      ?? $ Ellipse??6%    ? ??
 ?????6J   5&      5(      5*      5+      ?? 5-      " ??6'   .?5.   
   ??  ?@J?SnapsToDevicePixels$
 true??60   ?? 5/   
    ?@?OverridesDefaultStyle$
 true??62   ?? 50   
    ? ??$ false??6&   ?? 51   
    ? |?$ false??6&   ?? 52   
    ? ?? 53      ?? 54      " ??6"   .R?55      ?? $??1q?6   
???   ?
???   ?$??3??6Y   56      58      59      ?? 5;      " ??6(   .?5<   
   ??  ?@J?SnapsToDevicePixels$
 true??60   ?? 5=   
    ?@?OverridesDefaultStyle$
 true??62   ?? 5>   
    ? ?? 5?      ?? 5@      " ??6"   .R?5A      ?? $
 True??6   
??? ? ?$??1q?6L   
???2͚?$??3??6z   5B      5D      5E      ?? 5G      " n?6    .?5H   
   ??  ?@J?SnapsToDevicePixels$
 true??60   ?? 5I   
    ?@?OverridesDefaultStyle$
 true??62   ?? 5J   
    ? ?? 5K      ?? 5L      " n?6"   .R?5M      A? $??10??6   $??10??6*   
??? ? ?6D   5N      5P      5Q      ?? 5S      " ??6&   .R?5T   
   ?  5U      ?? 5V      $
??Auto ?6    ?? 5W      $
??Auto ?6    #??z??6.   ?? 5X      $
??Auto ?6    .+?5Z      ]? $ 
PART_Track??6!   $??1??6    5[      ?? 5\      8??  $??Slider.DecreaseLarge??6Q    5^      n? 5_      8?? 6    5a      ?? 5b      8?? $??Slider.IncreaseLarge??6O   5d      5e      5f      ?? 5h      " ??6&   .?5i   
   ??  ? |?$ False??6&   ?? 5j   
    ?@J?SnapsToDevicePixels$
 true??60   ?? 5k   
    ?@?OverridesDefaultStyle$
 true??62    5l   
   P? 5m      
 ?@??Orientation$ 
Horizontal=?6-   . ?5n      ??  ? ??$ 21??6.   ?? 5o       ? ??$	 104??6-   ?? 5p       ? ??8   6-   5q      5s      5t       ? DataContext 5v      ,   &WpfApp2.ViewModels.MainWindowViewModel  5w   
   .??5y      ]? .+?5z   
   o? $	??Top=?6   .@?5{      m? $
??File??6   .@?5}      m? $
??Exit??6    m? Command 6)   ?? *ExitCommand+5~      m? 5      $??About??6   m? 5?      $
??Help??6   m? 5?       m? CommandParameter$ -1??6:    6   ?? *ChangeTabIndex+??5?      ?? 5?      .+?5?        FontAwesome5.ImageAwesome  $??10??6*      Icon$ Solid_ArrowLeft=?65   6N   5?      5?      m? 5?      $ +1??6:    6   ?? *ChangeTabIndex+??5?      ?? 5?      .+?5?        $??10??6*   $ Solid_ArrowRight=?65   6O   5?      5?      m? 5?      ??6   ?? *SelectedTabIndex+ ?? UpdateSourceTrigger$ PropertyChanged=?6a   5?      ?? 5?   
   $??Bottom=?6   .@?5?      ?? .??5?      ?? ??6   ?? *Status+66   5?      ?? 5?      .??5?      ? $	??120??6=   $??15??6I   $??10 0 0 0q?6U    ? Value 6   ?? *SelectedTabIndex+??5?      ?? 5?      " ?6   .?5?      ??  ? ?? ?#2980b967   5?      5?      5?      ?? 5?      .??5?      ?? $	??120??6   $??5 0 0 0q?6%   #??[ 5?       5?   6   ?? *Name+5?      5?      5?      ?? 5?   
    ?? SelectedIndex 6   ?? *SelectedTabIndex+.@?5?      ?? $	??120??6   ??5?      ?? 5?       ?? Orientation$ 
Horizontal=?6!   .+?5?        $??0 0 10 0q?6+   $??30??6=   $??30??6I   $ Regular_ChartBar=?6U   ??5?      ?? 5?   "   "  6(   .?5?   &   ??  ?@ 
Foreground ?#9b59b66C    5?   &   P? 5?   *   
 ?@J?IsMouseOver$
 True??6I   . ?5?   .   ??  ?@ 
Foreground ?#8e44ad6]   5?   +   5?   #   5?      5?      .??5?      ? .+?5?        OxyPlot.Wpf.Plot     Axes 5?        OxyPlot.Wpf.LinearAxis  5?        OxyPlot.Wpf.Axis   Position$
 Left=?6,     5?      $ Bottom=?6,      Series 5?        OxyPlot.Wpf.LineSeries  5?        OxyPlot.Wpf.Series   Color$ #9b59b6??6,   !  OxyPlot.Wpf.DataPointSeries    
DataFieldX$  XValue??5?   ,   !   
DataFieldY$! YValue??5?   ,   ??5?   ,   ?? *
TestData+5?      5?      ?? 5?      $??2??6#   $??Right=?64   $??4??6P   5?      5?      ?? 5?      $	??120??6   $??Test 1??6#   ?? 5?      $	??120??6   $??Test 1??6#   ?? 5?      $	??120??6   $??Test 1??6#   ?? 5?      $	??120??6   $??Test 1??6#   ?? 5?      $	??120??6   $??Test 1??6#   5?      5?      5?      
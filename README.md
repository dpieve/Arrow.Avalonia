# Arrow.Avalonia
> Create a customizable Arrow with various configurations.

The Arrow Control is developed using Avalonia, making it compatible with multiple platforms including Windows, Linux, macOS, iOS, and Android.

## Features

- __Customizable Positions__: Define precise starting and ending positions for the arrow.
- __Fine-tuned Arrow Configuration__: Adjust the thickness of the arrow body, length, and width of the arrow head to meet specific requirements.
- __Flexible Head Style__: Choose between filled or unfilled arrow heads to suit different design preferences.
- __Color Selection__: Select the arrow's color to seamlessly integrate it with your application's visual style.

## Usage

Add the Arrow Control to your .axaml file. See the [sample project](https://github.com/dpieve/Arrow.Avalonia/blob/main/src/sample/Arrow.Avalonia.Sample/Views/MainView.axaml#L50).

```
<control:Arrow
         HeadLength="{Binding Arrow.HeadLength, Mode=TwoWay}"
         HeadWidth="{Binding Arrow.HeadWidth, Mode=TwoWay}"
         IsFilled="{Binding Arrow.IsHeadFilled}"
         IsProportional="{Binding Arrow.IsHeadProportional}"
         IsVisible="{Binding Arrow.IsVisible}"
         Thickness="{Binding Arrow.Thickness}"
         Color="{Binding Arrow.Color}"
         StartPoint="{Binding Arrow.Start}"
         EndPoint="{Binding Arrow.End}" />
```


## Contributing

Contributions to the Arrow Control project are welcome!

## Acknowledgments

Special thanks to [Avalonia](https://avaloniaui.net/) for providing the cross-platform UI framework.

## License

This project is license under the MIT License.
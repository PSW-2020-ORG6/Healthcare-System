XAML Coding guidelines
======================

## Rules

### Code readability

#### 1. Write only one attribute per line.
#### 2. The first line should have attribute.
#### 3. Within an element, order attributes alphabetically
#### 4. Put x:Name or x:Key as the first attribute
#### 5. Place attached properties after x:Name or x:Key
#### 6. If an element has no content, use a self-closing element
     
```xml
<Button x:Name="AddButton"
        Grid.Column="2"
        Grid.Row="0"
        Foreground="Blue"
        Text="Hello world" 
        />
```

### Naming

#### 1. Name elements with the x:Name or x:Key attribute
#### 2. Suffix XAML names with a type indication
#### 3. Name only nodes used in code-behind, element binding or animation

```xml
<Button x:Name="ValidationButton"
        Text="Hello world" 
        />
```

### Maintenability

#### 1. Use the rule of 3 to decide if a value must be declared as a resource
A violation of this rule occurs when a property value is used more than 2 times at different places.
#### 2. All the implicit styles must be placed at the top of the file and must be annotated with a comment
The implicit style must be used only when they apply to a whole page/app. If they apply only to a subset of a page/app,
they must be declared as explicit styles.

### Resource file organization

#### 1. Put the default styles within App.xaml, put other styles in another file
#### 2. Within a resource file, declare the elements in the following order

```
<!-- #Constants -->
<!-- #Colors -->
<!-- #Brushes -->
<!-- #Converters -->
<!-- #Objects (such as Data) or commands (for ribbon),etc. -->
<!-- #Styles -->
<!-- #DataTemplates -->
```

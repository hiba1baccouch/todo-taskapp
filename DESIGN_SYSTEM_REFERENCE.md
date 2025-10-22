# Design System Reference

Quick reference guide for maintaining design consistency.

## 🎨 Color Tokens

### Light Theme
```xml
<SolidColorBrush x:Key="BgLight" Color="#E8E8E8"/>
<SolidColorBrush x:Key="Surface" Color="#FFFFFF"/>
<SolidColorBrush x:Key="Border" Color="#E0E0E0"/>
<SolidColorBrush x:Key="Divider" Color="#F5F5F5"/>
<SolidColorBrush x:Key="TextPrimary" Color="#1A1A1A"/>
<SolidColorBrush x:Key="TextSecondary" Color="#6B6B6B"/>
<SolidColorBrush x:Key="TextMuted" Color="#999999"/>
<SolidColorBrush x:Key="Accent" Color="#A855F7"/>
<SolidColorBrush x:Key="AccentStrong" Color="#C757FF"/>
<SolidColorBrush x:Key="AccentSoft" Color="#F3E8FF"/>
```

### Dark Theme
```xml
<SolidColorBrush x:Key="BgLight" Color="#1C1F2E"/>
<SolidColorBrush x:Key="Surface" Color="#2C2F3E"/>
<SolidColorBrush x:Key="Border" Color="#3C3F4E"/>
<SolidColorBrush x:Key="Divider" Color="#4C4F5E"/>
<SolidColorBrush x:Key="TextPrimary" Color="#FFFFFF"/>
<SolidColorBrush x:Key="TextSecondary" Color="#B4B4B4"/>
<SolidColorBrush x:Key="TextMuted" Color="#8A8A8A"/>
<SolidColorBrush x:Key="Accent" Color="#A855F7"/>
<SolidColorBrush x:Key="AccentStrong" Color="#C757FF"/>
<SolidColorBrush x:Key="AccentSoft" Color="#3D2E5F"/>
```

### Status Colors (Both Themes)
```xml
<!-- Active/Success -->
<SolidColorBrush x:Key="ReminderActive" Color="#D1FAE5"/>
<SolidColorBrush x:Key="ReminderActiveText" Color="#059669"/>

<!-- Overdue/Error -->
<SolidColorBrush x:Key="ReminderOverdue" Color="#FEE2E2"/>
<SolidColorBrush x:Key="ReminderOverdueText" Color="#DC2626"/>

<!-- Not Set/Warning -->
<SolidColorBrush x:Key="ReminderNone" Color="#FEF3C7"/>
<SolidColorBrush x:Key="ReminderNoneText" Color="#D97706"/>
```

---

## 📐 Spacing Scale

```
4px   - xs   - Icon padding, micro adjustments
8px   - sm   - Button icon margins
12px  - md   - Default element spacing
16px  - lg   - Card/panel padding
24px  - xl   - Section margins
28px  - 2xl  - Large gaps
32px  - 3xl  - Card padding
35px  - 3.5xl- Section spacing
50px  - 4xl  - Column gaps
67px  - 5xl  - Hero section gaps
```

**Usage Example:**
```xml
Margin="0,0,12,0"  <!-- Right margin: 12px -->
Padding="32"        <!-- All sides: 32px -->
Margin="0,24,0,0"   <!-- Top margin: 24px -->
```

---

## 🔤 Typography

### Font Sizes
```xml
FontSize="36"  <!-- Title -->
FontSize="24"  <!-- Section Header -->
FontSize="20"  <!-- Card Title -->
FontSize="18"  <!-- Upcoming Task -->
FontSize="16"  <!-- Body Text -->
FontSize="14"  <!-- Body Small, Buttons -->
FontSize="13"  <!-- Captions, Labels -->
FontSize="12"  <!-- Tiny, Calendar Days -->
```

### Font Weights
```xml
FontWeight="SemiBold"  <!-- 600 - Titles, Headers -->
FontWeight="Medium"    <!-- 500 - Buttons, Emphasis -->
FontWeight="Normal"    <!-- 400 - Body Text -->
```

### Line Heights (via TextBlock)
```xml
LineHeight="54"  <!-- Title (36px font) -->
LineHeight="24"  <!-- Body (16px font) -->
```

---

## 🔘 Border Radius

```xml
CornerRadius="28"  <!-- Illustration card -->
CornerRadius="22"  <!-- Pills, Search field, Primary buttons -->
CornerRadius="20"  <!-- Floating sidebar, Modals -->
CornerRadius="16"  <!-- Cards, Tables -->
CornerRadius="14"  <!-- Calendar days, Secondary buttons -->
CornerRadius="13"  <!-- Nav pills -->
CornerRadius="12"  <!-- Input fields, Badge pills -->
CornerRadius="8"   <!-- Small buttons -->
CornerRadius="4"   <!-- Window controls -->
```

---

## 🎯 Component Sizes

### Buttons
```xml
<!-- Primary Button -->
Height="44" Padding="24,12" CornerRadius="22"

<!-- Nav Pill Button -->
Width="26" Height="26" CornerRadius="13"

<!-- Icon Button -->
Width="36" Height="36" CornerRadius="8"

<!-- Timer Button (Circle) -->
Width="55" Height="55" CornerRadius="27.5"

<!-- Window Control -->
Width="32" Height="32" CornerRadius="4"
```

### Input Fields
```xml
<!-- Search Field -->
Width="240" Height="44" CornerRadius="22"

<!-- Text Input -->
Height="44" Padding="14" CornerRadius="12"

<!-- Modal Input -->
Height="44" Padding="14" CornerRadius="12"
```

### Cards
```xml
<!-- Welcome Illustration -->
Width="305" Height="345" CornerRadius="28"

<!-- Calendar Card -->
Padding="32" CornerRadius="16"

<!-- Upcoming Card -->
Padding="16,16,30,16" CornerRadius="16"
```

---

## 🎨 Gradient

### Primary Gradient (Purple)
```xml
<LinearGradientBrush x:Key="ButtonGradient" StartPoint="0,0" EndPoint="1,1">
    <GradientStop Color="#C757FF" Offset="0"/>
    <GradientStop Color="#A855F7" Offset="1"/>
</LinearGradientBrush>
```

**Usage:**
```xml
Background="{DynamicResource ButtonGradient}"
```

---

## ✨ Shadows

### Card Shadow
```xml
<Border.Effect>
    <DropShadowEffect Color="Black" BlurRadius="20" ShadowDepth="4" Opacity="0.08"/>
</Border.Effect>
```

### Floating Sidebar Shadow
```xml
<Border.Effect>
    <DropShadowEffect Color="Black" BlurRadius="12" ShadowDepth="2" Opacity="0.1"/>
</Border.Effect>
```

---

## 🖼️ SVG Icon Template

### Basic Icon (24x24 canvas)
```xml
<Viewbox Width="18" Height="18">
    <Canvas Width="24" Height="24">
        <Path Data="[SVG Path Data]" 
              Stroke="{DynamicResource TextPrimary}" 
              StrokeWidth="2" 
              StrokeLineCap="Round" 
              StrokeLineJoin="Round" 
              Fill="Transparent"/>
    </Canvas>
</Viewbox>
```

### Icon in Button
```xml
<Button Width="36" Height="36">
    <Viewbox Width="18" Height="18">
        <Canvas Width="24" Height="24">
            <Path Data="M12 5v14M5 12h14" 
                  Stroke="{DynamicResource Accent}" 
                  StrokeWidth="2" 
                  StrokeLineCap="Round"/>
        </Canvas>
    </Viewbox>
</Button>
```

---

## 📦 Reusable Styles

### Using Existing Styles
```xml
<!-- Apply to any Button -->
Style="{StaticResource PrimaryButtonStyle}"
Style="{StaticResource NavPillStyle}"
Style="{StaticResource WindowButtonStyle}"
Style="{StaticResource TimerCircleStyle}"
Style="{StaticResource CalendarDayStyle}"

<!-- Apply to TextBox -->
Style="{StaticResource SearchFieldStyle}"
```

### Theme-Aware Colors
```xml
<!-- Always use DynamicResource for colors -->
Background="{DynamicResource Surface}"
Foreground="{DynamicResource TextPrimary}"
BorderBrush="{DynamicResource Border}"
```

---

## 🔍 Common Patterns

### Card with Shadow
```xml
<Border Background="{DynamicResource Surface}" 
        BorderBrush="{DynamicResource Border}" 
        BorderThickness="1" 
        CornerRadius="16" 
        Padding="32">
    <Border.Effect>
        <DropShadowEffect Color="Black" BlurRadius="20" ShadowDepth="4" Opacity="0.08"/>
    </Border.Effect>
    <!-- Content -->
</Border>
```

### Icon Button
```xml
<Button Width="36" Height="36" Background="Transparent" BorderThickness="0">
    <Viewbox Width="18" Height="18">
        <Canvas Width="24" Height="24">
            <!-- SVG Path -->
        </Canvas>
    </Viewbox>
</Button>
```

### Status Badge
```xml
<Border Background="{StaticResource ReminderActive}" 
        CornerRadius="12" 
        Padding="14,8">
    <TextBlock Text="Active" 
               FontSize="12" 
               FontWeight="SemiBold" 
               Foreground="{StaticResource ReminderActiveText}"/>
</Border>
```

---

## ✅ Design Checklist

When adding new components:

- [ ] Use dynamic resources for all colors
- [ ] Follow spacing scale (4, 8, 12, 16, 24, 32, etc.)
- [ ] Use proper border radius from system
- [ ] Apply appropriate shadows to elevated elements
- [ ] Use SVG icons instead of emojis
- [ ] Set proper font size and weight
- [ ] Add hover/pressed states for interactive elements
- [ ] Test in both light and dark themes
- [ ] Maintain consistent padding/margins
- [ ] Follow typography hierarchy

---

## 📚 Resources

- **Theme Files:** `/Themes/lightTheme.xaml`, `/Themes/darkTheme.xaml`
- **Assets:** `/assets/icons/`, `/assets/images/`
- **Implementation Guide:** `FIGMA_DESIGN_IMPLEMENTATION.md`
- **Conversion Summary:** `DESIGN_CONVERSION_SUMMARY.md`

---

**Last Updated:** October 2025  
**Version:** 1.0  
**Status:** ✅ Complete & Production Ready

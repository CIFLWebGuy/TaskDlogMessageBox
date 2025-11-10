using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TaskDlogMessageBox
{
    public enum StandardButtons
    {
        Close,
        OK,
        OKCancel,
        AbortRetryIgnore,
        YesNo,
        YesNoCancel,
        RetryCancel,
        CancelTryContinue
    }

    public static class TaskDialogMessageBox
    {
        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options with an expanded area and a footnote.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <param name="icon">One of the <see cref="TaskDialogIcon" /> values that specifies the icon to display in the dialog.</param>
        /// <param name="defaultButton">One of the <see cref="MessageBoxDefaultButton "/> values that specifies the default button for the dialog.</param>
        /// <param name="expandedText">The text to display in the expanded area.</param>
        /// <param name="footnoteIcon">The icon to display in the footnote area.</param>
        /// <param name="footnoteText">The text display in the footnote area. </param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(IWin32Window owner, string? instruction, string? text, string? caption, StandardButtons buttons, TaskDialogIcon icon, MessageBoxDefaultButton? defaultButton, string? expandedText, TaskDialogIcon? footnoteIcon, string? footnoteText)
        {
            TaskDialogPage page = new TaskDialogPage();
            page.Text = text;
            page.Caption = caption;
            page.Heading = instruction;
            page.Icon = icon;

            AddButtons(page,  buttons);
            SetDefaultButton(page, defaultButton);
            
            if(expandedText  != null)
            {
                TaskDialogExpander expander = new TaskDialogExpander();
                expander.Text = expandedText;
                expander.CollapsedButtonText = "More details";
                expander.ExpandedButtonText = "Hide details";
                expander.Position = TaskDialogExpanderPosition.AfterText;

                page.Expander = expander;
            }

            if(footnoteIcon != null)
            {
                TaskDialogFootnote footnote = new TaskDialogFootnote();
                footnote.Text = footnoteText;
                footnote.Icon = footnoteIcon;

                page.Footnote = footnote;
            }

            return TaskDialog.ShowDialog(owner, page);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options with an expanded area.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <param name="icon">One of the <see cref="TaskDialogIcon" /> values that specifies the icon to display in the dialog.</param>
        /// <param name="defaultButton">One of the <see cref="MessageBoxDefaultButton "/> values that specifies the default button for the dialog.</param>
        /// <param name="expandedText">The text to display in the expanded area.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(IWin32Window owner, string? instruction, string? text, string? caption, StandardButtons buttons, TaskDialogIcon icon, MessageBoxDefaultButton? defaultButton, string? expandedText)
        {
            return Show(owner, instruction, text, caption, buttons, icon, defaultButton, expandedText, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <param name="icon">One of the <see cref="TaskDialogIcon" /> values that specifies the icon to display in the dialog.</param>
        /// <param name="defaultButton">One of the <see cref="MessageBoxDefaultButton "/> values that specifies the default button for the dialog.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(IWin32Window owner, string? instruction, string? text, string? caption, StandardButtons buttons, TaskDialogIcon icon, MessageBoxDefaultButton? defaultButton)
        {
            return Show(owner, instruction, text, caption, buttons, icon, defaultButton, null, null, null);
        }       

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <param name="icon">One of the <see cref="TaskDialogIcon" /> values that specifies the icon to display in the dialog.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(IWin32Window owner, string? instruction, string? text, string? caption, StandardButtons buttons, TaskDialogIcon icon)
        {
            return Show(owner, instruction, text, caption, buttons, icon, null, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(IWin32Window owner, string? instruction, string? text, string? caption, StandardButtons buttons)
        {
            return Show(owner, instruction, text, caption, buttons, TaskDialogIcon.None, null, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(IWin32Window owner, string? instruction, string? text, string? caption)
        {
            return Show(owner, instruction, text, caption, StandardButtons.Close, TaskDialogIcon.None, null, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified instruction text, secondary text, no icon nad the default Close button.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(IWin32Window owner, string? instruction, string? text)
        {
            return Show(owner, instruction, text, null, StandardButtons.Close, TaskDialogIcon.None, null, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified instruction text, no icon and the default Close button.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(IWin32Window owner, string? instruction)
        {
            return Show(owner, instruction, null, null, StandardButtons.Close, TaskDialogIcon.None, null, null, null, null);
        }


        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options with an expanded area and a footnote.
        /// </summary>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <param name="icon">One of the <see cref="TaskDialogIcon" /> values that specifies the icon to display in the dialog.</param>
        /// <param name="defaultButton">One of the <see cref="MessageBoxDefaultButton "/> values that specifies the default button for the dialog.</param>
        /// <param name="expandedText">The text to display in the expanded area.</param>
        /// <param name="footnoteIcon">The icon to display in the footnote area.</param>
        /// <param name="footnoteText">The text display in the footnote area. </param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(string? instruction, string? text, string? caption, StandardButtons buttons, TaskDialogIcon icon, MessageBoxDefaultButton? defaultButton, string? expandedText, TaskDialogIcon? footnoteIcon, string? footnoteText)
        {
            TaskDialogPage page = new TaskDialogPage();
            page.Text = text;
            page.Caption = caption;
            page.Heading = instruction;
            page.Icon = icon;

            AddButtons(page, buttons);
            SetDefaultButton(page, defaultButton);

            if (expandedText != null)
            {
                TaskDialogExpander expander = new TaskDialogExpander();
                expander.Text = expandedText;
                expander.CollapsedButtonText = "More details";
                expander.ExpandedButtonText = "Hide details";
                expander.Position = TaskDialogExpanderPosition.AfterText;

                page.Expander = expander;
            }

            if (footnoteIcon != null)
            {
                TaskDialogFootnote footnote = new TaskDialogFootnote();
                footnote.Text = footnoteText;
                footnote.Icon = footnoteIcon;

                page.Footnote = footnote;
            }

            return TaskDialog.ShowDialog(page);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options with an expanded area.
        /// </summary>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <param name="icon">One of the <see cref="TaskDialogIcon" /> values that specifies the icon to display in the dialog.</param>
        /// <param name="defaultButton">One of the <see cref="MessageBoxDefaultButton "/> values that specifies the default button for the dialog.</param>
        /// <param name="expandedText">The text to display in the expanded area.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(string? instruction, string? text, string? caption, StandardButtons buttons, TaskDialogIcon icon, MessageBoxDefaultButton? defaultButton, string? expandedText)
        {
            return Show(instruction, text, caption, buttons, icon, defaultButton, expandedText, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <param name="icon">One of the <see cref="TaskDialogIcon" /> values that specifies the icon to display in the dialog.</param>
        /// <param name="defaultButton">One of the <see cref="MessageBoxDefaultButton "/> values that specifies the default button for the dialog.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(string? instruction, string? text, string? caption, StandardButtons buttons, TaskDialogIcon icon, MessageBoxDefaultButton? defaultButton)
        {
            return Show(instruction, text, caption, buttons, icon, defaultButton, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <param name="icon">One of the <see cref="TaskDialogIcon" /> values that specifies the icon to display in the dialog.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(string? instruction, string? text, string? caption, StandardButtons buttons, TaskDialogIcon icon)
        {
            return Show(instruction, text, caption, buttons, icon, null, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <param name="buttons">One of the <see cref="StandardButtons" /> values that specifies the buttons to display in the dialog.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(string? instruction, string? text, string? caption, StandardButtons buttons)
        {
            return Show(instruction, text, caption, buttons, TaskDialogIcon.None, null, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified options.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <param name="caption">The dialog box window caption.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(string? instruction, string? text, string? caption)
        {
            return Show(instruction, text, caption, StandardButtons.Close, TaskDialogIcon.None, null, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified instruction text, secondary text, no icon nad the default Close button.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <param name="text">The primary text.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(string? instruction, string? text)
        {
            return Show(instruction, text, null, StandardButtons.Close, TaskDialogIcon.None, null, null, null, null);
        }

        /// <summary>
        /// Displays a standard message box using a <see cref="TaskDialog" /> with the specified instruction text, no icon and the default Close button.
        /// </summary>
        /// <param name="owner">The window that owns the dialog box.</param>
        /// <param name="instruction">The main instruction text.</param>
        /// <returns>A <see cref="TaskDialogButton" /> value that specifies which button was pressed.</returns>
        public static TaskDialogButton Show(string? instruction)
        {
            return Show(instruction, null, null, StandardButtons.Close, TaskDialogIcon.None, null, null, null, null);
        }

        private static void AddButtons(TaskDialogPage page, StandardButtons? buttons)
        {
            if(buttons == null)
            {
                page.Buttons.Add(TaskDialogButton.Close);
                return;
            }

            switch (buttons)
            {
                case StandardButtons.Close:
                    page.Buttons.Add(TaskDialogButton.Close);
                    break;

                case StandardButtons.OK:
                    page.Buttons.Add(TaskDialogButton.OK);
                    break;

                case StandardButtons.OKCancel:
                    page.Buttons.Add(TaskDialogButton.OK);
                    page.Buttons.Add(TaskDialogButton.Cancel);

                    break;

                case StandardButtons.AbortRetryIgnore:
                    page.Buttons.Add(TaskDialogButton.Abort);
                    page.Buttons.Add(TaskDialogButton.Retry);
                    page.Buttons.Add(TaskDialogButton.Ignore);
                    break;

                case StandardButtons.YesNo:
                    page.Buttons.Add(TaskDialogButton.Yes);
                    page.Buttons.Add(TaskDialogButton.No);

                    break;

                case StandardButtons.RetryCancel:
                    page.Buttons.Add(TaskDialogButton.Retry);
                    page.Buttons.Add(TaskDialogButton.Cancel);

                    break;

                case StandardButtons.YesNoCancel:
                    page.Buttons.Add(TaskDialogButton.Yes);
                    page.Buttons.Add(TaskDialogButton.No);
                    page.Buttons.Add(TaskDialogButton.Cancel);

                    break;

                case StandardButtons.CancelTryContinue:
                    page.Buttons.Add(TaskDialogButton.Cancel);
                    page.Buttons.Add(TaskDialogButton.TryAgain);
                    page.Buttons.Add(TaskDialogButton.Continue);
                    
                    break;

            }
        }

        private static void SetDefaultButton(TaskDialogPage page, MessageBoxDefaultButton? defaultButton)
        {
            if (defaultButton == null)
            {
                return;
            }

            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    page.DefaultButton = page.Buttons[0];
                    break;

                case MessageBoxDefaultButton.Button2:
                    if (page.Buttons.Count < 2)
                    {
                        throw new ArgumentException("Button does not exist.");
                    }

                    page.DefaultButton = page.Buttons[1];
                    break;

                case MessageBoxDefaultButton.Button3:
                    if (page.Buttons.Count < 3)
                    {
                        throw new ArgumentException("Button does not exist.");
                    }

                    page.DefaultButton = page.Buttons[2];
                    break;
            }

        }
    }
}

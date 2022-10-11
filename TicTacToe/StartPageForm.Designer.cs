
namespace TicTacToe
{
    partial class StartPageForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPageForm));
            this.smallSizeBoardRadio = new System.Windows.Forms.RadioButton();
            this.bigSizeBoardRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.boardSizePanel = new System.Windows.Forms.Panel();
            this.gameTypePanel = new System.Windows.Forms.Panel();
            this.playerVsPlayerRadio = new System.Windows.Forms.RadioButton();
            this.playerVsBotRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.botVsBotRadio = new System.Windows.Forms.RadioButton();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.boardSizePanel.SuspendLayout();
            this.gameTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // smallSizeBoardRadio
            // 
            this.smallSizeBoardRadio.AutoSize = true;
            this.smallSizeBoardRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smallSizeBoardRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.smallSizeBoardRadio.Location = new System.Drawing.Point(40, 3);
            this.smallSizeBoardRadio.Name = "smallSizeBoardRadio";
            this.smallSizeBoardRadio.Size = new System.Drawing.Size(46, 20);
            this.smallSizeBoardRadio.TabIndex = 0;
            this.smallSizeBoardRadio.TabStop = true;
            this.smallSizeBoardRadio.Text = "3x3";
            this.smallSizeBoardRadio.UseVisualStyleBackColor = true;
            // 
            // bigSizeBoardRadio
            // 
            this.bigSizeBoardRadio.AutoSize = true;
            this.bigSizeBoardRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bigSizeBoardRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bigSizeBoardRadio.Location = new System.Drawing.Point(138, 3);
            this.bigSizeBoardRadio.Name = "bigSizeBoardRadio";
            this.bigSizeBoardRadio.Size = new System.Drawing.Size(46, 20);
            this.bigSizeBoardRadio.TabIndex = 1;
            this.bigSizeBoardRadio.TabStop = true;
            this.bigSizeBoardRadio.Text = "5x5";
            this.bigSizeBoardRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите размер поля для игры:";
            // 
            // boardSizePanel
            // 
            this.boardSizePanel.Controls.Add(this.bigSizeBoardRadio);
            this.boardSizePanel.Controls.Add(this.smallSizeBoardRadio);
            this.boardSizePanel.Location = new System.Drawing.Point(65, 53);
            this.boardSizePanel.Name = "boardSizePanel";
            this.boardSizePanel.Size = new System.Drawing.Size(219, 24);
            this.boardSizePanel.TabIndex = 4;
            // 
            // gameTypePanel
            // 
            this.gameTypePanel.Controls.Add(this.botVsBotRadio);
            this.gameTypePanel.Controls.Add(this.playerVsPlayerRadio);
            this.gameTypePanel.Controls.Add(this.playerVsBotRadio);
            this.gameTypePanel.Location = new System.Drawing.Point(57, 154);
            this.gameTypePanel.Name = "gameTypePanel";
            this.gameTypePanel.Size = new System.Drawing.Size(257, 82);
            this.gameTypePanel.TabIndex = 6;
            // 
            // playerVsPlayerRadio
            // 
            this.playerVsPlayerRadio.AutoSize = true;
            this.playerVsPlayerRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playerVsPlayerRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerVsPlayerRadio.Location = new System.Drawing.Point(3, 29);
            this.playerVsPlayerRadio.Name = "playerVsPlayerRadio";
            this.playerVsPlayerRadio.Size = new System.Drawing.Size(163, 20);
            this.playerVsPlayerRadio.TabIndex = 1;
            this.playerVsPlayerRadio.TabStop = true;
            this.playerVsPlayerRadio.Text = "Игрок против игрока";
            this.playerVsPlayerRadio.UseVisualStyleBackColor = true;
            // 
            // playerVsBotRadio
            // 
            this.playerVsBotRadio.AutoSize = true;
            this.playerVsBotRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playerVsBotRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerVsBotRadio.Location = new System.Drawing.Point(3, 3);
            this.playerVsBotRadio.Name = "playerVsBotRadio";
            this.playerVsBotRadio.Size = new System.Drawing.Size(198, 20);
            this.playerVsBotRadio.TabIndex = 0;
            this.playerVsBotRadio.TabStop = true;
            this.playerVsBotRadio.Text = "Игрок против компьютера";
            this.playerVsBotRadio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(131, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Стиль игры:";
            // 
            // botVsBotRadio
            // 
            this.botVsBotRadio.AutoSize = true;
            this.botVsBotRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.botVsBotRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.botVsBotRadio.Location = new System.Drawing.Point(3, 55);
            this.botVsBotRadio.Name = "botVsBotRadio";
            this.botVsBotRadio.Size = new System.Drawing.Size(232, 20);
            this.botVsBotRadio.TabIndex = 2;
            this.botVsBotRadio.TabStop = true;
            this.botVsBotRadio.Text = "Компьютер против компьютера";
            this.botVsBotRadio.UseVisualStyleBackColor = true;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(129, 270);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(115, 26);
            this.StartGameButton.TabIndex = 7;
            this.StartGameButton.Text = "Начать игру";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // StartPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(358, 308);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.gameTypePanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boardSizePanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartPageForm";
            this.Text = "Tic Tac Toe";
            this.boardSizePanel.ResumeLayout(false);
            this.boardSizePanel.PerformLayout();
            this.gameTypePanel.ResumeLayout(false);
            this.gameTypePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton smallSizeBoardRadio;
        private System.Windows.Forms.RadioButton bigSizeBoardRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel boardSizePanel;
        private System.Windows.Forms.Panel gameTypePanel;
        private System.Windows.Forms.RadioButton botVsBotRadio;
        private System.Windows.Forms.RadioButton playerVsPlayerRadio;
        private System.Windows.Forms.RadioButton playerVsBotRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartGameButton;
    }
}


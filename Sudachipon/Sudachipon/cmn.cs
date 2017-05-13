using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudachipon
{
    static class cmn
    {
        // 名前の空欄チェック
        public static bool ValidationCheck_NameIsNotNull(String str)
        {
            // nameが空欄、空白の場合は処理終了
            String strValidCheck = str;
            if (String.IsNullOrEmpty(strValidCheck) || String.IsNullOrEmpty(strValidCheck.Trim()))
            {
                MessageBox.Show("名前は空白以外の文字を記入してください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;

        }

        // Form1:メイン画面
        public const String ST_MSG_起動時 = "hogefuga";

        // FrmPcMasterMaintenance：PCマスタ画面

        // FrmSoftwareMasterMaintenance:ソフトウェアマスタ画面

        // FrmUserMasterMaintenance:userマスタ画面:USM
        public const String ST_MSG_USM_起動時 = "Userマスタのデータを読み込みました。";
        public const String ST_MSG_USM_追加時 = "新規Userを追加しました。";
        public const String ST_MSG_USM_削除時 = "Userを削除しました。";
        public const String ST_MSG_USM_更新時 = "Userの情報を更新しました。";
        public const String ST_MSG_USM_ドラッグ時 = "当該Softwareをドロップして下さい。";
        public const String ST_MSG_USM_ドロップ時 = "UserにSoftwareを追加しました。";
        public const String ST_MSG_USM_ソフト削除時 = "UserからSoftwareを削除しました。";
    }
}

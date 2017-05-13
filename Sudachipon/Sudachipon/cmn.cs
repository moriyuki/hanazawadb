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

        // Form1:メイン画面:FRM
        public const String ST_MSG_FRM_接続成功 = "DBに接続し、データを読み込みました。";
        public const String ST_MSG_FRM_接続失敗 = "DBへの接続に失敗しました。";
        public const String ST_MSG_FRM_登録成功 = "指定日・指定PCにユーザーを登録しました。";
        public const String ST_MSG_FRM_登録失敗 = "ユーザーの登録に失敗しました。";
        public const String ST_MSG_FRM_削除成功 = "指定日・指定PCからユーザーを削除しました。";
        public const String ST_MSG_FRM_削除失敗 = "ユーザーの削除に失敗しました。";

        // FrmPcMasterMaintenance：PCマスタ画面:PCM

        // FrmSoftwareMasterMaintenance:ソフトウェアマスタ画面:SFM

        // FrmUserMasterMaintenance:userマスタ画面:USM
    }
}

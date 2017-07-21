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
        public const String ST_MSG_FRM_登録失敗ソフトウェア未インストール = "ソフトウェアがインストールされていないので登録に失敗しました。";
        public const String ST_MSG_FRM_削除成功 = "指定日・指定PCからユーザーを削除しました。";
        public const String ST_MSG_FRM_削除失敗 = "ユーザーの削除に失敗しました。";

        // FrmPcMasterMaintenance：PCマスタ画面:PCM

        // FrmSoftwareMasterMaintenance:ソフトウェアマスタ画面
        public const String ST_MSG_SFM_フォーム起動時_正常 = "Softwareマスタのデータを読み込みました。";
        public const String ST_MSG_SFM_フォーム起動時_異常 = "Softwareマスタの読み込みに失敗しました。";
        public const String ST_MSG_SFM_Add時_正常 = "新規Softwareを追加しました。";
        public const String ST_MSG_SFM_Add時_異常 = "新規Softwareの追加に失敗しました。";
        public const String ST_MSG_SFM_Delete時_正常 = "Softwareを削除しました。";
        public const String ST_MSG_SFM_Delete時_異常 = "Softwareの削除に失敗しました。";
        public const String ST_MSG_SFM_Update時_正常 = "Softwareの情報を更新しました。";
        public const String ST_MSG_SFM_Update時_異常 = "Softwareの情報の更新に失敗しました。";
        public const String ST_MSG_SFM_PCMasterからのドラッグ時_正常 = "当該PCをドロップして下さい。";
        public const String ST_MSG_SFM_PCMasterからのドラッグ時_異常 = "当該PCはドロップできません。";
        public const String ST_MSG_SFM_PCMasterからのドロップ時_正常 = "PCにSoftwareを追加しました。";
        public const String ST_MSG_SFM_PCMasterからのドロップ時_異常 = "PCのSoftwareの追加に失敗しました。";
        public const String ST_MSG_SFM_PCsからの削除時_正常 = "PCからSoftwareを削除しました。";
        public const String ST_MSG_SFM_PCsからの削除時_異常 = "PCのSoftwareの削除に失敗しました。";
        public const String ST_MSG_SFM_UserMasterからのドラッグ時_正常 = "当該Userをドロップして下さい。";
        public const String ST_MSG_SFM_UserMasterからのドラッグ時_異常 = "当該Userはドロップできません。";
        public const String ST_MSG_SFM_UserMasterからのドロップ時_正常 = "UserにSoftwareを追加しました。";
        public const String ST_MSG_SFM_UserMasterからのドロップ時_異常 = "UserのSoftwareの追加に失敗しました。";
        public const String ST_MSG_SFM_Usersからの削除時_正常 = "UserからSoftwareを削除しました。";
        public const String ST_MSG_SFM_Usersからの削除時_異常 = "UserのSoftwareの削除に失敗しました。";


        // FrmUserMasterMaintenance:userマスタ画面:USM
        public const String ST_MSG_USM_起動時 = "Userマスタのデータを読み込みました。";
        public const String ST_MSG_USM_追加時 = "新規Userを追加しました。";
        public const String ST_MSG_USM_削除時 = "Userを削除しました。";
        public const String ST_MSG_USM_更新時 = "Userの情報を更新しました。";
        public const String ST_MSG_USM_ドラッグ時 = "当該Softwareをドロップして下さい。";
        public const String ST_MSG_USM_ドラッグ制約時 = "当該Softwareはドロップできません。";
        public const String ST_MSG_USM_ドロップ時 = "UserにSoftwareを追加しました。";
        public const String ST_MSG_USM_ソフト削除時 = "UserからSoftwareを削除しました。";
    }
}

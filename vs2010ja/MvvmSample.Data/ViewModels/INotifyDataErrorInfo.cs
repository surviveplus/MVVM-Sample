using System;
using System.Collections;

namespace MvvmSample.Data.ViewModels
{
    /// <summary>
    /// カスタムの同期検証および非同期検証サポートを提供するためにデータ エンティティ クラスに実装できるメンバーを定義します。
    /// 
    /// System.ComponentModel.INotifyDataErrorInfo と同じ実装を .net 4.0 用に用意したクラスです。
    /// このサンプルでは、.net 4.5 以降の実装に近いイメージで実装するようにしています。
    /// .net 4.0 のデータバインドはこの方式をサポートしていないため、ビューを工夫してバリデーションエラー時に自分でエラーを表示するようにしています。
    /// またXAMLの大きな違いは、Validation.ErrorTemplateを使用できないため、エラー表示をコントロールごとに自分で配置していることです。
    /// </summary>
    public interface INotifyDataErrorInfo
    {
        /// <summary>
        /// エンティティに検証エラーがあるかどうかを示す値を取得します。
        /// </summary>
        /// <value>現在エンティティに検証エラーがある場合は true。それ以外の場合は false。</value>
        bool HasErrors { get; }

        /// <summary>
        /// プロパティまたはエンティティ全体の検証エラーが変更されたときに発生します。
        /// </summary>
        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// 指定されたプロパティまたはエンティティ全体の検証エラーを取得します。
        /// </summary>
        /// <param name="propertyName">検証エラーを取得するプロパティの名前。または、エンティティ レベルのエラーを取得する場合は null または System.String.Empty。</param>
        /// <returns>プロパティまたはエンティティの検証エラー。</returns>
        IEnumerable GetErrors(string propertyName);
    }

    /// <summary>
    /// System.ComponentModel.INotifyDataErrorInfo.ErrorsChanged イベントにデータを提供します。
    /// </summary>
    public class DataErrorsChangedEventArgs : EventArgs
    {
        /// <summary>
        /// System.ComponentModel.DataErrorsChangedEventArgs クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="propertyName">エラーがあるプロパティの名前です。エラーがオブジェクト レベルの場合、null または System.String.Empty です。</param>
        public DataErrorsChangedEventArgs(string propertyName) {
            this.PropertyName = propertyName;
        }

        /// <summary>
        /// エラーのあるプロパティの名前を取得します。
        /// </summary>
        /// <value>エラーのあるプロパティの名前。エラーがオブジェクト レベルの場合、null または System.String.Empty となります。</value>
        public virtual string PropertyName { get; private set; }
    }
}

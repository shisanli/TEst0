﻿namespace CustomerSkin.Controls
{
    /// <summary>
    /// Interface IPageControl
    /// </summary>
    public interface IPageControl
    {
        /// <summary>
        /// 数据源改变时发生
        /// </summary>
        event PageControlEventHandler ShowSourceChanged;
        /// <summary>
        /// 数据源
        /// </summary>
        /// <value>The data source.</value>
        List<object> DataSource { get; set; }
        /// <summary>
        /// 显示数量
        /// </summary>
        /// <value>The size of the page.</value>
        int PageSize { get; set; }
        /// <summary>
        /// 开始下标
        /// </summary>
        /// <value>The start index.</value>
        int StartIndex { get; set; }
        /// <summary>
        /// 第一页
        /// </summary>
        void FirstPage();
        /// <summary>
        /// 前一页
        /// </summary>
        void PreviousPage();
        /// <summary>
        /// 下一页
        /// </summary>
        void NextPage();
        /// <summary>
        /// 最后一页
        /// </summary>
        void EndPage();
        /// <summary>
        /// 重新加载
        /// </summary>
        void Reload();
        /// <summary>
        /// 获取当前页数据
        /// </summary>
        /// <returns>List&lt;System.Object&gt;.</returns>
        List<object> GetCurrentSource();
        /// <summary>
        /// 总页数
        /// </summary>
        /// <value>The page count.</value>
        int PageCount { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        /// <value>The index of the page.</value>
        int PageIndex { get; set; }
        PageModel PageModel { get; set; }
    }
}

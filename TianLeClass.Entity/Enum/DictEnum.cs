using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TianLeClass.Entity.Enum
{
    public enum DictEnum
    {
        /// <summary>
        /// banner第一行文字
        /// </summary>
        [Description("90%的孩子都喜欢")]
        ActivityCouponBannerTextMain,
        /// <summary>
        /// banner第二行文字
        /// </summary>
        [Description("给孩子试试?")]
        ActivityCouponBannerTextSub,
        /// <summary>
        /// banner图片
        /// </summary>
        ActivityCouponBannerImg,

        /// <summary>
        /// 消息滚动开始时间
        /// </summary>
        [Description("8:00")]
        ActivityCouponRollInfoOpenTime,

        /// <summary>
        /// 消息滚动结束时间
        /// </summary>
        [Description("22:00")]
        ActivityCouponRollInfoCloseTime,

        /// <summary>
        /// 活动大标题
        /// </summary>
        [Description("免费领取")]
        ActivityCouponTitleMain,

        /// <summary>
        /// 活动小标题
        /// </summary>
        [Description("价值799元的暑期系统班")]
        ActivityCouponTitleSub,

        /// <summary>
        /// 新初一
        /// </summary>
        grade7,
        /// <summary>
        /// 新初二
        /// </summary>
        grade8,
        /// <summary>
        /// 新初三
        /// </summary>
        grade9

    }
}

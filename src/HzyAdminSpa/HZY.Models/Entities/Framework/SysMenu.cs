using System;
using HZY.Models.Entities.BaseEntitys;

namespace HZY.Models.Entities.Framework;

/// <summary>
/// 菜单
/// </summary>
public class SysMenu : DefaultBaseEntity<Guid>
{
    /// <summary>
    /// 编号
    /// </summary>
    public int? Number { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Vue组件名称
    /// </summary>
    public string ComponentName { get; set; }

    /// <summary>
    /// 菜单物理路径
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 路由地址
    /// </summary>
    public string Router { get; set; }

    /// <summary>
    /// 默认跳转地址
    /// </summary>
    public string JumpUrl { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 是否显示菜单
    /// </summary>
    public int Show { get; set; } = 1;

    /// <summary>
    /// 是否可关闭
    /// </summary>
    public int Close { get; set; } = 1;


}
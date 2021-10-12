/**
 * 程序常量
 */
const appConsts = {
    /**
     * token 键值
     */
    tokenKey: "Authorization_HZY_ADMIN_Spa",
    /**
     * 域名
     */
    domainName: process.env.NODE_ENV == "production" ? "" : "http://localhost:5600",

    /**
     * Guid Empty String
     */
    guidEmpty: '00000000-0000-0000-0000-000000000000',
};

export default appConsts;
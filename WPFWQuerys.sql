SELECT U.Email, R.Name
FROM AspNetUsers U
JOIN AspNetUserRoles UR
    ON U.Id = UR.UserId
JOIN AspNetRoles R
    ON R.Id = UR.RoleId
ORDER BY U.Email, R.Name;
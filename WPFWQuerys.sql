INSERT INTO AspNetUserRoles(UserId, RoleId)
VALUES (
    '21762cd7-3f29-4ebc-a021-1b3f34465e33',
    '00c39fbc-7410-4456-85c5-4bf9e1672bea'
);

SELECT U.Email, R.Name
FROM AspNetUsers U
JOIN AspNetUserRoles UR
    ON U.Id = UR.UserId
JOIN AspNetRoles R
    ON R.Id = UR.RoleId;